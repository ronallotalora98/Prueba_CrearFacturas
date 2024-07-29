import { DetalleFactura } from "./detalleFactura";

export interface CrearFacturaRequest {

  id?:number;
  fechaEmisionFactura: Date
  idCliente: number;
  numeroFactura: number;
  numeroTotalArticulos: number;
  subTotalFacturas: number;
  totalImpuestos: number;
  totalFactura: number;
  detalleFactura: DetalleFactura[];
}

export interface CrearFacturaResponse{
  id:number;
}
