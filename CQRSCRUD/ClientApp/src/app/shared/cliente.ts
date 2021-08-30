export class Cliente {
  id: string;
  razaoSocial: string;
  cnpj: string;
  dataCadastramento: string;

  constructor() {
    this.id = '0';
    this.razaoSocial = '';
    this.cnpj = '';
    this.dataCadastramento = new Date().toLocaleDateString();
  }
}
