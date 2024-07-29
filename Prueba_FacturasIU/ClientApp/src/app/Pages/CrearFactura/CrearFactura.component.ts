import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CrearFacturaRequest } from 'src/app/models/crearFacturaRequest';
import { DetalleFactura } from 'src/app/models/detalleFactura';
import { Producto } from 'src/app/models/producto';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-CrearFactura',
  templateUrl: './CrearFactura.component.html',
  styleUrls: ['./CrearFactura.component.css']
})
export class CrearFacturaComponent implements OnInit ,OnDestroy {

  constructor(private productoService: ProductoService) { }

  crearFactura: CrearFacturaRequest = {

    fechaEmisionFactura: new Date(),
    idCliente: 0,
    numeroFactura: 0,
    numeroTotalArticulos: 0,
    subTotalFacturas: 0,
    totalImpuestos: 0,
    totalFactura: 0,
    detalleFactura: []
  };

  listadoProductos: DetalleFactura[] = [];

  detalleFactura: DetalleFactura = {
    idProducto: 0,
    cantidadDeProducto: 1,
    precioUnitarioProducto: 0,
    subtotalProducto: 0,
    notas: '',
    total: 0
  }

  productos:Producto[] = [];
  private subscription: Subscription = new Subscription();

  ngOnInit() {
    this.getProductos();
  }

  getProductos() {
    this. subscription.add(this.productoService.getProductos().subscribe(res => {
      this.productos = res;
    }))
  }


  addNewProduct() {

    this.listadoProductos.push(this.detalleFactura);

  }


  GuardarFactura() {

  }


  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
