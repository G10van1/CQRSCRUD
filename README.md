# CQRSCRUD
<h2>CRUD Clientes com CQRS</h2>
<p>Exemplo de CRUD de Clientes com uso das seguintes tecnologias:</p>
<ul>
  <li><a href='https://get.asp.net/'>ASP.NET Core</a> e <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> para o código do back-end;</li>
  <li><a href='https://angular.io/'>Angular</a> e <a href='http://www.typescriptlang.org/'>TypeScript</a> Para o código do front-end;</li>
  <li><a href='http://getbootstrap.com/'>Bootstrap</a> para o layout e estilo;</li>
  <li>Banco de dados SQL Server;</li>
  <li>ORM Entity Framework;</li>
  <li>Padrão de Arquitetura CQRS(Command and Query Responsibility Segregation);</li>
  <li>Padrão de projeto Mediator com Dependency Injection.</li>
</ul>

<h3>Algumas informações para o deploy:</h3>
<ul>
  <li>Na pasta Database existe um script do banco de dados, este deve ser importado no SQL Server;</li>
  <li>No projeto principal (CQRSCRUD), atualizar a configuração de “Data Source” do atributo “DefaultConnection”, no arquivo “appsettings.json” que fica na raiz do projeto;/li>
  <li>No projeto de teste unitário (CQRSCRUDTest), atualizar o valor da variável “baseUrl” do método “Setup” com a nova Url da aplicação./li>
</ul>

