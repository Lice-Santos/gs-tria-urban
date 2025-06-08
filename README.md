# TRIA URBAN

---

## 👥 Integrantes do Grupo

| Nome                      | RM      |
|---------------------------|---------|
| Alice Nunes dos Santos    | 559052  |
| Anne Rezendes Martins     | 556779  |
| Guilherme Akira Nakamatsu | 556128  |

---

## 📝 Resumo da Solução

Enchentes urbanas causam perdas de vidas, danos materiais e interrompem serviços essenciais.  
**TRIA URBAN** foi pensado para:

1. **Solicitar Ajuda**  
   Descreva seu problema, escolha os itens necessários e envie sua solicitação aos pontos de distribuição mais próximos.

2. **Cadastrar Pontos de Distribuição**  
   Seja voluntário: registre locais — casas, ONGs, comércios — onde doações podem ser recebidas e distribuídas.

3. **Encontrar Pontos Perto de Mim**  
   Use sua localização atual para localizar, rapidamente, os pontos que têm exatamente o que você precisa.

---

## 📊 Diagramas de Fluxo

<p align="center">
  <img src="https://github.com/user-attachments/assets/2d4dea6d-c45e-4b8b-9f12-dcfc6d98d40c" alt="Fluxo de Solicitação" width="45%"/>
  <img src="https://github.com/user-attachments/assets/adfa8ce3-c3c3-48e7-b00d-5c55b25a4e71" alt="Cadastro de Ponto" width="45%"/>
</p>
<p align="center">
  <img src="https://github.com/user-attachments/assets/7ce64b9f-a55f-4f8d-86df-2b1a85f90f1b" alt="Localização no Mapa" width="60%"/>
</p>

---

## 🚀 Rotas Disponíveis

### 📂 EnderecoController

| Método | Rota                                  | Descrição                           |
|--------|---------------------------------------|-------------------------------------|
| GET    | `/api/Endereco`                       | Lista todos os endereços            |
| GET    | `/api/Endereco/{id}`                  | Busca endereço por ID               |
| GET    | `/api/Endereco/cep/{cep}`             | Busca por CEP                       |
| GET    | `/api/Endereco/logradouro/{logradouro}` | Busca por logradouro               |
| GET    | `/api/Endereco/cidade/{cidade}`       | Filtra por cidade                   |
| POST   | `/api/Endereco`                       | Cria novo endereço                  |
| PUT    | `/api/Endereco/{id}`                  | Atualiza endereço                   |
| DELETE | `/api/Endereco/{id}`                  | Remove endereço                     |

---

### 📂 EstoqueItemController

| Método | Rota                                   | Descrição                             |
|--------|----------------------------------------|---------------------------------------|
| GET    | `/api/EstoqueItem`                     | Lista todos os itens de estoque       |
| GET    | `/api/EstoqueItem/{id}`                | Busca por ID                          |
| GET    | `/api/EstoqueItem/item/{idItem}`       | Lista estoques de um item específico  |
| GET    | `/api/EstoqueItem/ponto/{idPonto}`     | Lista estoques de um ponto específico |
| POST   | `/api/EstoqueItem`                     | Cria item de estoque                  |
| PUT    | `/api/EstoqueItem/{id}`                | Atualiza item de estoque              |
| DELETE | `/api/EstoqueItem/{id}`                | Remove item de estoque                |

---

### 📂 ItemController

| Método | Rota                              | Descrição                    |
|--------|-----------------------------------|------------------------------|
| GET    | `/api/Item`                       | Lista todos os itens         |
| GET    | `/api/Item/{id}`                  | Busca item por ID            |
| GET    | `/api/Item/nome/{nome}`           | Busca por nome (parcial)     |
| GET    | `/api/Item/categoria/{categoria}`| Filtra por categoria         |
| POST   | `/api/Item`                       | Cria novo item               |
| PUT    | `/api/Item/{id}`                  | Atualiza item existente      |
| DELETE | `/api/Item/{id}`                  | Remove item                  |

---

### 📂 PontoDistribuicaoController

| Método | Rota                                   | Descrição                          |
|--------|----------------------------------------|------------------------------------|
| GET    | `/api/PontoDistribuicao`               | Lista todos os pontos de distribuição |
| GET    | `/api/PontoDistribuicao/{id}`          | Busca ponto por ID                 |
| GET    | `/api/PontoDistribuicao/nome/{nome}`   | Filtra por nome                    |
| GET    | `/api/PontoDistribuicao/tipo/{tipo}`   | Filtra por tipo (enum)             |
| POST   | `/api/PontoDistribuicao`               | Cria novo ponto de distribuição    |
| PUT    | `/api/PontoDistribuicao/{id}`          | Atualiza ponto existente           |
| DELETE | `/api/PontoDistribuicao/{id}`          | Remove ponto                       |

---

### 📂 UsuarioController

| Método | Rota                                    | Descrição                     |
|--------|-----------------------------------------|-------------------------------|
| GET    | `/api/Usuario`                          | Lista todos os usuários       |
| GET    | `/api/Usuario/{id}`                     | Busca usuário por ID          |
| GET    | `/api/Usuario/nome/{nome}`              | Filtra por nome               |
| GET    | `/api/Usuario/username/{username}`      | Filtra por username           |
| POST   | `/api/Usuario`                          | Cria novo usuário             |
| PUT    | `/api/Usuario/{id}`                     | Atualiza usuário existente    |
| DELETE | `/api/Usuario/{id}`                     | Remove usuário                |

---

## ✅ Exemplos de Testes via Swagger

> Para cada controller, execute cenários de sucesso e erro.

---

### 📌 EnderecoController

1. **GET `/api/Endereco`**  
   - ✅ Retorna lista de endereços (200 OK).  
   - ❌ Se não houver registros, retorna `[]` (200 OK).  


2. **GET `/api/Endereco/cep/{cep}`**  
   - ✅ CEP válido (`12345678`) retorna dados do endereço.  
   - ❌ CEP mal formatado (`123`) retorna 400 Bad Request.  
   - ❌ CEP não cadastrado retorna 404 Not Found.

3. **POST `/api/Endereco`**  
   - ✅ Body com `logradouro`, `cidade`, `cep` válidos retorna 201 Created.  
   - ❌ `cep` com mais de 8 dígitos retorna 400 Bad Request.  
   - ❌ `logradouro` vazio retorna 400 Bad Request.

---

### 📌 EstoqueItemController

1. **GET `/api/EstoqueItem/item/{idItem}`**  
   - ✅ `idItem` existente retorna lista de estoques.  
   - ❌ `idItem` inexistente retorna 404 Not Found.  
   - ❌ `idItem` texto (`"abc"`) retorna 400 Bad Request.

2. **POST `/api/EstoqueItem`**  
   - ✅ JSON com `idItem`, `quantidade`, `dataEntrada` válidos retorna 200 OK.  
   - ❌ `quantidade` negativa retorna 400 Bad Request.  
   - ❌ `dataEntrada` em formato inválido retorna 400 Bad Request.

3. **DELETE `/api/EstoqueItem/{id}`**  
   - ✅ `id` existente retorna 204 No Content.  
   - ❌ `id` inexistente retorna 404 Not Found.  
   - ❌ `id` como string (`"xyz"`) retorna 400 Bad Request.

---

### 📌 ItemController

1. **GET `/api/Item/{id}`**  
   - ✅ `id` válido retorna dados do item (200 OK).  
   - ❌ `id` inexistente retorna 404 Not Found.  
   - ❌ `id` inválido (`"abc"`) retorna 400 Bad Request.

2. **GET `/api/Item/nome/{nome}`**  
   - ✅ Nome parcial (`"Camisa"`) retorna lista de itens.  
   - ❌ Nome que não existe retorna `[]` (200 OK).  


3. **POST `/api/Item`**  
   - ✅ Body com campos válidos retorna 201 Created.  
   - ❌ `nome` em branco retorna 400 Bad Request.  
   - ❌ `categoria` inválida retorna 400 Bad Request.

---

### 📌 PontoDistribuicaoController

1. **GET `/api/PontoDistribuicao/{id}`**  
   - ✅ `id` existente retorna dados do ponto.  
   - ❌ `id` inexistente retorna 404 Not Found.  
   - ❌ `id` texto retorna 400 Bad Request.

2. **POST `/api/PontoDistribuicao`**  
   - ✅ JSON válido retorna 200 OK.  
   - ❌ `nome` vazio retorna 400 Bad Request.  
   - ❌ `enderecoId` inexistente retorna 404 Not Found.

---

### 📌 UsuarioController

1. **GET `/api/Usuario/{id}`**  
   - ✅ `id` existente retorna dados do usuário.  
   - ❌ `id` inexistente retorna 404 Not Found.  
   - ❌ `id` como string retorna 400 Bad Request.

2. **GET `/api/Usuario/username/{username}`**  
   - ✅ `username` existente retorna lista.  
   - ❌ `username` não cadastrado retorna `[]` (200 OK).  
   - ❌ Rota incorreta (`/api/Usuario/user/{username}`) retorna 404.

3. **POST `/api/Usuario`**  
   - ✅ Body com `nome`, `username`, `email` válidos retorna 201 Created.  
   - ❌ `username` duplicado retorna 400 Bad Request.  
   - ❌ `email` mal formatado retorna 400 Bad Request.

---

## ⚙️INSTALAÇÃO ##
**Bibliotecas instaladas:**
- dotnet add package Microsoft.EntityFrameworkCore.Design
- dotnet add package Microsoft.EntityFrameworkCore
- dotnet add package Microsoft.EntityFrameworkCore.Tools
- dotnet add package Oracle.EntityFrameworkCore

**EF Core:**
- dotnet tool install --global dotnet-ef

**Comandos Utilizados para Criação do Migration:**
- Add-Migration InitialCreate
- dotnet ef migrations add InitialCreate

##🎥 VÍDEOS##

| Tipo                | Descrição                            | Link                                                                   |
| ------------------- | ------------------------------------ | ---------------------------------------------------------------------- |
| 📢 **Pitch**        | Apresentação rápida do projeto       | [Assista no YouTube](https://youtu.be/H7F3I7Zxw-w?si=jwK8nPOAQlF8tWlr) |
| 💻 **Demonstração** | Demonstração prática com código real | [Assista no YouTube](https://www.youtube.com/watch?v=XduTg134Q-U)      |
