import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CrearFacturaComponent } from './CrearFactura/CrearFactura.component';
import { ListaFacturasComponent } from './ListaFacturas/ListaFacturas.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'crearFactura', component: CrearFacturaComponent },
  { path: 'listaFactura', component: ListaFacturasComponent },

  { path: '', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule {}
