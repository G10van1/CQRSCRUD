import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { Cliente } from '../shared/cliente';

@Component({
  selector: 'app-addCliente-component',
  templateUrl: './addCliente.component.html'
})
export class AddClienteComponent implements OnInit {
  formCliente: FormGroup;
  private Id: string;
  private baseUrl: string;
  private httpClient: HttpClient;
  public cliente: Cliente;
  public router: Router;

  constructor(private location: Location, private activatedRoute: ActivatedRoute, http: HttpClient, @Inject('BASE_URL') Url: string) {
    this.baseUrl = Url;
    this.httpClient = http;
    this.Id = this.activatedRoute.snapshot.paramMap.get('id');
    this.cliente = new Cliente();
    this.loadClient();
    this.createForm(this.cliente);
  }

  loadClient() {
    if (this.Id != '0') {
      const url = `${this.baseUrl}api/Cliente/${this.Id}`;
      this.httpClient.get<Cliente>(url).subscribe(result => {
        this.cliente = result;
      }, error => console.error(error));
    }
    else
      this.cliente.dataCadastramento = new Date().toLocaleDateString();
  }

  ngOnInit() {
  }

  createForm(cliente: Cliente) {
    this.formCliente = new FormGroup({
      razaoSocial: new FormControl(cliente.razaoSocial),
      cnpj: new FormControl(cliente.cnpj),
      dataCadastramento: new FormControl(cliente.dataCadastramento)
    })
  }

  onSubmit() {
    const rzSocial = this.formCliente.get('razaoSocial').value;
    this.cliente.razaoSocial = rzSocial != '' ? rzSocial : this.cliente.razaoSocial;
    const cnpj = this.formCliente.get('cnpj').value;
    this.cliente.cnpj = cnpj != '' ? cnpj : this.cliente.cnpj;
    if (this.cliente.razaoSocial == '' || this.cliente.cnpj == '') {
      alert('Campo não pode ser vazio !');
      return;
    }
    if (this.cliente.id != '0')
      this.putClient();
    else
      this.postClient();
    // Usar o método reset para limpar os controles na tela
    this.cliente = new Cliente();
    this.formCliente.reset();
    this.location.back();
  }

  postClient() {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf8' })
    }

    const url = `${this.baseUrl}api/Cliente`;
    let json = JSON.stringify(this.cliente);
    json = json.replace('{\"id\":\"0\",', '{');
    this.httpClient.post<Cliente>(url, json, httpOptions).subscribe(
      val => {
        console.log("POST call successful value returned in body", val);
      },
      response => {
        console.log("POST call in error", response);
      },
      () => {
        console.log("The POST observable is now completed.");
      }
    );
  }

  putClient() {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf8' })
    }
    const url = `${this.baseUrl}api/Cliente`;
    const json = JSON.stringify(this.cliente);
    this.httpClient.put(url, json, httpOptions).subscribe(
      val => {
        console.log("PUT call successful value returned in body", val);
      },
      response => {
        console.log("PUT call in error", response);
      },
      () => {
        console.log("The PUT observable is now completed.");
      }
    );
  }
}
