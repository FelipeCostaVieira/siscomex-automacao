Siscomex Automação

Projeto de automação web utilizando .NET 8 + Playwright + MySQL, com foco em consultas automatizadas no sistema Siscomex Web, utilizando autenticação via certificado digital A1.

--------------------------------------------------
ARQUITETURA DA SOLUÇÃO
--------------------------------------------------

A solução está organizada em camadas para facilitar manutenção, escalabilidade e trabalho em equipe:

Siscomex.Automacao
├── Core
├── Application
├── Infrastructure
└── Runner

--------------------------------------------------
DESCRIÇÃO DOS PROJETOS
--------------------------------------------------

Core:
- Contém estruturas base e entidades do sistema
- Não depende de tecnologias externas

Application:
- Responsável pela lógica de negócio
- Orquestra os fluxos da automação
- Exemplo: ConsultaDiService

Infrastructure:
- Responsável por integrações externas
- Contém:
  - Automação com Playwright
  - Conexão com banco MySQL
  - Repositórios
  - Fabricação do navegador

Principais componentes:
- FabricaNavegador
- MySqlConnectionFactory
- DiRepository

Runner:
- Ponto de entrada da aplicação
- Executa os fluxos
- Não deve conter regra de negócio

--------------------------------------------------
TECNOLOGIAS UTILIZADAS
--------------------------------------------------

- .NET 8
- Playwright
- MySQL
- Git / GitHub

--------------------------------------------------
CONFIGURAÇÃO DE AMBIENTE
--------------------------------------------------

Antes de executar, configure as variáveis de ambiente:

DB_CONN=Server=localhost;Database=siscomex_automacao;Uid=root;Pwd=senha;
CERT_PATH=C:\certificados\certificado.pfx
CERT_PASS=senha_certificado

--------------------------------------------------
EXECUÇÃO DO PROJETO
--------------------------------------------------

dotnet build
dotnet run --project Siscomex.Automacao.Runner

--------------------------------------------------
ESTRATÉGIA DE BRANCHES
--------------------------------------------------

main        → produção (estável)
develop     → integração do time
feature/*   → desenvolvimento individual

--------------------------------------------------
FLUXO DE TRABALHO
--------------------------------------------------

1. Criar branch a partir de develop:
   git checkout develop
   git pull
   git checkout -b feature/nome-da-feature

2. Desenvolver e commitar:
   git add .
   git commit -m "feat: descrição"

3. Subir para o repositório:
   git push origin feature/nome-da-feature

4. Abrir Pull Request para develop

5. Revisão de código

6. Merge após aprovação

--------------------------------------------------
SETUP DO AMBIENTE (PARA NOVOS DESENVOLVEDORES)
--------------------------------------------------

git clone https://github.com/FelipeCostaVieira/siscomex-automacao.git
cd siscomex-automacao

dotnet restore

Configurar variáveis de ambiente (DB_CONN, CERT_PATH, CERT_PASS)

Executar:
dotnet run --project Siscomex.Automacao.Runner

--------------------------------------------------
OBJETIVO INICIAL DO PROJETO
--------------------------------------------------

Automatizar consultas de DI no Siscomex Web, com captura de dados e persistência em banco de dados.

--------------------------------------------------
OBSERVAÇÕES IMPORTANTES
--------------------------------------------------

- Não subir certificados (.pfx) no repositório
- Não versionar senhas
- Utilizar sempre variáveis de ambiente
- Não trabalhar diretamente nas branches main ou develop
- Sempre usar feature branches