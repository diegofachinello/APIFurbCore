import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-or-update',
  templateUrl: './add-or-update.component.html',
  styleUrls: ['./add-or-update.component.css']
})
export class AddOrUpdateComponent implements OnInit {

  @Output() usuarioCreated = new EventEmitter<any>();
  @Input() usuarioInfo: any;

  public buttonText = 'Salvar';

  ngOnInit() {
  }

  constructor() { 
    this.clearUsuarioInfo();
    console.log(this.usuarioInfo.id);
  }

  private clearUsuarioInfo = function() {
    // Create an empty user object
    this.usuarioInfo = {
      id: undefined,
      email: '',
      senha: ''
    };
  };

  public addOrUpdateUsuario = function(event) {
    this.usuarioCreated.emit(this.usuarioInfo);
    this.clearUsuarioInfo();
  };
}
