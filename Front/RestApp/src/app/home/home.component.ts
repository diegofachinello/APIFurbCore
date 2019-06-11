import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../usuario.service'
import * as _ from 'lodash';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public usuarioData: Array<any>;
  public currentUsuario: any;
  
  constructor(private usuarioService: UsuarioService) {
    usuarioService.get().subscribe((data: any) => this.usuarioData = data);
    this.currentUsuario = this.setInitialValuesForUsuarioData();
   }

  ngOnInit() {
  }

   private setInitialValuesForUsuarioData () {
    return {
      id: undefined,
      email: '',
      senha: ''
    }
  }

public createOrUpdateUsuario = function(usuario: any) {
    let usuarioWithId;
    usuarioWithId = _.find(this.usuarioData, (el => el.id === usuario.id));

    if (usuarioWithId) {
      const updateIndex = _.findIndex(this.usuarioData, {id: usuarioWithId.id});
      this.usuarioService.update(usuario).subscribe(
        usuarioRecord => this.usuarioData.splice(updateIndex, 1, usuario)
      );
    } else {
      this.usuarioService.add(usuario).subscribe(
        usuarioRecord => this.usuarioData.push(usuario)
      );
    }

    this.currentUsuario = this.setInitialValuesForUsuarioData();
  };

  public editClicked = function(record) {
    this.currentUsuario = record;
  };

  public newClicked = function() {
    this.currentUsuario = this.setInitialValuesForUsuarioDataData(); 
  };

  public deleteClicked(record) {
    const deleteIndex = _.findIndex(this.usuarioData, {id: record.id});
    this.usuarioService.remove(record).subscribe(
      result => this.usuarioData.splice(deleteIndex, 1)
    );
  }
}
