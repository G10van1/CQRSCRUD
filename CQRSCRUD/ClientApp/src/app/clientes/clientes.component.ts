import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Cliente } from '../shared/cliente';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent {
  public clientes: Cliente[];
  private baseUrl: string;
  private httpClient: HttpClient;
  public router: Router;

  constructor(http: HttpClient, @Inject('BASE_URL') Url: string) {
    this.baseUrl = Url;
    this.httpClient = http;
    this.loadClientes();
  }

  loadClientes()
  {
    this.httpClient.get<Cliente[]>(this.baseUrl + 'api/Cliente').subscribe(result => {
      this.clientes = result;
    }, error => console.error(error));
  }

  async handleDelete(id: string, razaoSocial: string) {
    const evtMsg = id ? ' Deseja excluir cliente ' + razaoSocial + ' id = ' + id + ' ?': '';
    if (!confirm(evtMsg)) {
      return;
    }
        
    await this.httpClient.delete<Cliente[]>(this.baseUrl + 'api/Cliente/' + id).subscribe(data => {
      console.log(data);
      this.loadClientes();
    });
  }
}

