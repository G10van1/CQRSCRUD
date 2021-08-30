"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Cliente = void 0;
var Cliente = /** @class */ (function () {
    function Cliente() {
        this.id = '0';
        this.razaoSocial = '';
        this.cnpj = '';
        this.dataCadastramento = new Date().toLocaleDateString();
    }
    return Cliente;
}());
exports.Cliente = Cliente;
//# sourceMappingURL=cliente.js.map