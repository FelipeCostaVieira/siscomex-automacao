# 🚀 Siscomex Automação

Projeto de automação web utilizando **.NET 8 + Playwright + MySQL**, com foco em consultas automatizadas no sistema **Siscomex Web**, utilizando autenticação via **certificado digital A1**.

---

## 🧱 Arquitetura da Solução

A solução segue uma arquitetura em camadas:

```
Siscomex.Automacao
├── Core
├── Application
├── Infrastructure
└── Runner
```

---

## 📦 Descrição dos Projetos

### 🔹 Core
Contém estruturas base e entidades do sistema.

- Não depende de tecnologias externas  
- Base para as demais camadas  

---

### 🔹 Application
Responsável pela lógica de negócio e orquestração dos fluxos.

Exemplo:
- `ConsultaDiService`

---

### 🔹 Infrastructure
Responsável por integrações externas.

Contém:
- Automação com Playwright  
- Conexão com MySQL  
- Repositórios  
- Fabricação do navegador  

Principais classes:
- `FabricaNavegador`
- `MySqlConnectionFactory`
- `DiRepository`

---

### 🔹 Runner
Ponto de entrada da aplicação.

- Executa os fluxos  
- Não contém regra de negócio  

---

## ⚙️ Tecnologias Utilizadas

- 🧠 .NET 8  
- 🌐 Playwright  
- 🗄️ MySQL  
- 🔧 Git / GitHub  

---

## 🔐 Configuração de Ambiente

Configure as variáveis de ambiente:

```
DB_CONN=Server=localhost;Database=siscomex_automacao;Uid=root;Pwd=senha;
CERT_PATH=C:\certificados\certificado.pfx
CERT_PASS=senha_certificado
```

---

## ▶️ Execução

```bash
dotnet build
dotnet run --project Siscomex.Automacao.Runner
```

---

## 🌿 Estratégia de Branches

```
main        → produção (estável)
develop     → integração do time
feature/*   → desenvolvimento individual
```

---

## 🔁 Fluxo de Trabalho

```bash
# Criar branch
git checkout develop
git pull
git checkout -b feature/nome-da-feature

# Trabalhar
git add .
git commit -m "feat: descrição"
git push origin feature/nome-da-feature
```

Depois:
👉 Abrir Pull Request para `develop`

---

## 👥 Setup para Desenvolvedores

```bash
git clone https://github.com/FelipeCostaVieira/siscomex-automacao.git
cd siscomex-automacao
dotnet restore
```

Configurar variáveis de ambiente:

- `DB_CONN`
- `CERT_PATH`
- `CERT_PASS`

Executar:

```bash
dotnet run --project Siscomex.Automacao.Runner
```

---

## 🎯 Objetivo Inicial

Automatizar consultas de **Declaração de Importação (DI)** no Siscomex Web, com:

- captura de dados  
- rastreabilidade  
- persistência em banco  

---

## ⚠️ Boas Práticas

- ❌ Não subir certificados (`.pfx`)  
- ❌ Não versionar senhas  
- ✅ Utilizar variáveis de ambiente  
- ❌ Não trabalhar direto na `main` ou `develop`  
- ✅ Sempre usar `feature/*`  

---

## 📌 Status do Projeto

🚧 Em desenvolvimento inicial  
✔ Infraestrutura pronta  
✔ Banco configurado  
✔ Playwright integrado  
🚀 Próximo passo: automação real do Siscomex
