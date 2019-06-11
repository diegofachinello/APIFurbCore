import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { UsuarioService } from './usuario.service';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import * as _ from 'lodash';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { GridAppComponent } from './grid-app/grid-app.component';
import { FormsModule } from '@angular/forms';
import { AddOrUpdateComponent } from './add-or-update/add-or-update.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent }
 
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GridAppComponent,
    AddOrUpdateComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    FormsModule
  ],
  providers: [
    UsuarioService
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
