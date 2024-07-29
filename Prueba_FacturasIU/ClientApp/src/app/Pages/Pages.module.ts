import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagesComponent } from './Pages.component';
import { HomeComponent } from './home/home.component';
import { PagesRoutingModule } from './pages-routing.module';
import { CrearFacturaComponent } from './CrearFactura/CrearFactura.component';
import { ListaFacturasComponent } from './ListaFacturas/ListaFacturas.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    PagesRoutingModule,
    FormsModule
  ],
  declarations: [
    PagesComponent,
    HomeComponent,
    CrearFacturaComponent,
    ListaFacturasComponent
  ]
})
export class PagesModule { }
