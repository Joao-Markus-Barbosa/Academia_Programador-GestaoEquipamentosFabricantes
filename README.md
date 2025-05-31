# 💻 Academia do Programador - Sistema de Gestão de Equipamentos

Este é um projeto de aplicação **console em C#**, desenvolvido como parte da atividade prática da **Academia do Programador**. O sistema tem como objetivo simular o controle de **equipamentos**, **chamados de manutenção** e **fabricantes**, de forma simples e didática, utilizando os conceitos fundamentais de programação estruturada.

---

## 📚 Objetivo da Atividade

O personagem Junior cuida do estoque de equipamentos em sua empresa e precisa de um sistema simples que substitua suas planilhas do Excel. O software foi criado para **automatizar as tarefas rotineiras**, como cadastros, edições e exclusões de equipamentos, fabricantes e chamados de manutenção.

---

## 🧩 Funcionalidades Implementadas

### ✅ Módulo de Equipamentos
- Cadastro de equipamentos com:
  - Nome (mín. 6 caracteres)
  - Preço de aquisição
  - Número de série
  - Data de fabricação
  - Fabricante vinculado
- Listagem completa de todos os equipamentos
- Edição e exclusão de equipamentos cadastrados

### ✅ Módulo de Chamados
- Registro de chamados de manutenção, vinculando ao equipamento
- Visualização de chamados com:
  - Equipamento relacionado
  - Data de abertura
  - Quantidade de dias em aberto
- Edição e exclusão de chamados

### ✅ Módulo de Fabricantes
- Cadastro de fabricantes com:
  - Nome
  - Email
  - Telefone
- Listagem dos fabricantes com:
  - Quantidade de equipamentos cadastrados por fabricante
- Edição e exclusão de fabricantes

---

## 🏗️ Estrutura do Projeto

O projeto foi organizado em **módulos separados por pasta**, para manter a estrutura limpa e de fácil manutenção.

```
Academia_Programador_GestaoEquipamentosFabricantes/
│
├── Program.cs                         # Menu principal
│
├── ModuloEquipamento/
│   ├── Equipamento.cs
│   ├── RepositorioEquipamento.cs
│   └── TelaEquipamento.cs
│
├── ModuloChamado/
│   ├── Chamado.cs
│   ├── RepositorioChamado.cs
│   └── TelaChamado.cs
│
├── ModuloFabricante/
│   ├── Fabricante.cs
│   ├── RepositorioFabricante.cs
│   └── TelaFabricante.cs
```

---

## 🚀 Tecnologias Utilizadas

- `C#` (.NET 6 ou superior)
- `Console Application`
- `Programação Estruturada`
- `List<T>` para simulação de banco de dados em memória

---

## 🏁 Como Executar o Projeto

1. Abra o Visual Studio.
2. Execute o projeto como **Aplicação de Console (.NET)**.
3. Use as opções do menu para navegar entre os módulos.

---

## 👨‍🏫 Atividade Acadêmica

Este projeto foi desenvolvido como parte das atividades da **Academia do Programador**, com foco no desenvolvimento da lógica de programação, organização de código e estruturação modular de um sistema realista e funcional.

---

## 📌 Observações

- Nenhum banco de dados é utilizado: os dados são armazenados temporariamente em listas.
- Ideal para estudantes que estão aprendendo os fundamentos da programação C#.

---

