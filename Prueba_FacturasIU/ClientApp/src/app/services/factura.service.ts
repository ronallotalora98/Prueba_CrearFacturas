import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CrearFacturaRequest, CrearFacturaResponse } from '../models/crearFacturaRequest';

@Injectable({
  providedIn: 'root'
})
export class FacturaService {

  private apiUrl = environment.urlApi + 'api/Factura';

  constructor(private http: HttpClient) { }

  GuardarFactura(facturaRequest: CrearFacturaRequest): Observable<CrearFacturaResponse> {
    return this.http.post<CrearFacturaResponse>(`${this.apiUrl}`, facturaRequest);
  }

}
