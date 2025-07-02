# Biblioteca 📚

> Projeto full-stack de uma biblioteca, com **ASP.NET Core** no backend e **Vue 3 + Vuetify** no frontend.

## 📌 Sobre

Este repositório contém o projeto completo da aplicação **Biblioteca**, dividido em duas partes principais:
- **Backend**: API RESTful feita com **ASP.NET Core** e documentação automática via **Swagger/OpenAPI**
- **Frontend**: Aplicação web construída com **Vue 3** e **Vuetify** (em desenvolvimento)

---

## 📁 Estrutura do Projeto

```
Biblioteca/
├── Back/        # Backend da aplicação
│   └── api/     # API (em desenvolvimento)
├── Front/       # Frontend (a ser implementado)
└── .gitignore   # Configuração do Git
```

---

## 🔧 Tecnologias Utilizadas

### Backend
- **.NET 8**
- **ASP.NET Core** (Web API)
- **Swagger/OpenAPI** para documentação automática

### Frontend (em desenvolvimento)
- **Vue 3**
- **Vuetify**

---

## 🚀 Como Rodar o Projeto (Backend)

1. **Clone o repositório**
    ```bash
    git clone https://github.com/BerBG/Biblioteca.git 
    cd Biblioteca/Back/api
    ```

2. **Restaure as dependências e rode a API**
    ```bash
    dotnet restore
    dotnet run
    ```

3. **Acesse a API**
    - Endpoints principais:  
      `http://localhost:5036/api/livro`
    - Documentação Swagger:  
      `http://localhost:5036/swagger`

---

## ✅ Conteúdo Atual

- Backend funcional com endpoints para livros
- DTOs e mapeamento implementados
- Documentação automática com Swagger
- Pronto para expansão

---

## 🌐 Futuras Funcionalidades

- Cadastro de livros e usuários
- Empréstimo e devolução
