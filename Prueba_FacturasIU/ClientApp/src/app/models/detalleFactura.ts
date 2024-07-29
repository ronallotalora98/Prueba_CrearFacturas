export interface DetalleFactura {
  id?: number;
  idFactura?: number;
  idProducto: number;
  cantidadDeProducto: number;
  precioUnitarioProducto : number;
  subtotalProducto: number;
  notas: string;
  total:number;
}
