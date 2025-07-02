# Biblioteca 📚

> Projeto full-stack de uma biblioteca desenvolvido com ASP.NET Core no backend e Vue 3 + Vuetify no frontend.

## 📌 Sobre

Este repositório contém o projeto completo da aplicação **Biblioteca**, dividido em duas partes principais:
- **Backend**: API RESTful feita com **ASP.NET Core Minimal APIs** e **OpenAPI**
- **Frontend**: Aplicação web construída com **Vue 3** e estilizada com **Vuetify** (atualmente em desenvolvimento)

---

## 📁 Estrutura do Projeto

Biblioteca/
├── Back/ # Backend da aplicação
│ └── api/ # API (sendo implementado)
├── Front/ # Frontend (a ser implementado posteriormente)
└── .gitignore # Arquivo de configuração do Git


---

## 🔧 Tecnologias Utilizadas

### Backend
- **.NET 9**
- **ASP.NET Core** com **Minimal APIs**
- **OpenAPI** para documentação automática

### Frontend (em desenvolvimento)
- **Vue 3**
- **Nuxt 3**
- **Vuetify**

---

## 🚀 Como Rodar o Projeto (Backend)

1. **Clone o repositório**

```bash
git clone https://github.com/BerBG/Biblioteca.git 
cd Biblioteca
```bash

2. Acesse a pasta da API

```bash
cd Back/api
```bash

3. Restaure as dependências e rode a API

```bash
dotnet restore
dotnet run
```bash

4. Acesse a API localmente

Abra seu navegador e acesse:
http://localhost:5000/weatherforecast

5. Documentação da API

Se quiser visualizar a documentação gerada automaticamente:
http://localhost:5000/openapi/v1.json

✅ Conteúdo Atual
No momento, este repositório contém apenas o backend da aplicação :

Uma API Web mínima criada com dotnet new webapi
Configurada com suporte a OpenAPI (sem uso de Swashbuckle)
Com endpoints básicos como /weatherforecast
Configuração limpa e pronta para expansão

🌐 Futuras Funcionalidades (Ideias)
Quando o projeto estiver completo, ele terá:

Sistema de cadastro de livros e usuários
Empréstimo e devolução de livros
Login de usuário com autenticação JWT
Interface amigável com Vuetify
Testes unitários e integração CI/CD no GitHub Actions

✅ Contribuições
Contribuições são bem-vindas! Se você quiser melhorar o projeto, adicionar novas funcionalidades ou corrigir bugs, fique à vontade.

Como contribuir:
Fork o projeto
Crie uma nova branch (git checkout -b feature/nova-feature)
Faça suas alterações e faça commit (git commit -m "Add nova feature")
Push na sua branch (git push origin feature/nova-feature)
Abra um Pull Request

📞 Contato
Bernardo Portes
📧 bgferreira0@gmail.com
GitHub: @BerBG
