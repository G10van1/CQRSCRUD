import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['./fetch-data.component.css']
})
export class FetchDataComponent {
  public clientes: Clientes[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Clientes[]>(baseUrl + 'api/Cliente').subscribe(result => {
      this.clientes = result;
    }, error => console.error(error));
  }

  newClient(event?: MouseEvent) {
    const evtMsg = event ? ' Inserir novo cliente ' + (event.target as HTMLElement).textContent : '';
    alert(evtMsg);
    if (event) { event.stopPropagation(); }
  }

  //handleEdit(id: string) {
 // handleEdit(event?: MouseEvent) {
  handleEdit(id: string) {
    //const id = '1'
   
    const evtMsg = id ? ' Editar cliente ' + id : '';
    alert(evtMsg);
  }

  //handleDelete(id: string, razaoSocial: string) {
  //handleDelete(event?: MouseEvent, id: string, razaoSocial: string) {
  handleDelete(id: string, razaoSocial: string) {
    const evtMsg = id ? ' Deletar cliente ' + razaoSocial + ' id = ' + id : '';
    alert(evtMsg);
  }
}

interface Clientes {
  id: string
  razaoSocial: string;
  cnpj: string;
  dataCadastramento: string;
}
