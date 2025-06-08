create database pcp;
use pcp;

create table estrategicos (
  cod_es int primary key not null auto_increment,
  nome_es varchar(100) not null unique,
  sal_es decimal(5,3) not null check(sal_es > 0),
  experiencia_es varchar(50) not null,
  formacao_es varchar(50) not null,
  status_es varchar(20) not null check(status_es in ('ativo', 'inativo')),
  data_contratacao date not null,
  cargo_es varchar(100),
  departamento_es varchar(100),
  nivel_hierarquico_es varchar(50),
  data_nascimento date,
  email_es varchar(100),
  senha_es varchar(50),
  cpf_es char(14)
);

create table taticos (
  cod_ta int primary key not null auto_increment,
  nome_ta varchar(100) not null unique,
  sal_ta decimal(5,3) not null check(sal_ta > 0),
  experiencia_ta varchar(50) not null,
  formacao_ta varchar(50) not null,
  status_ta varchar(20) not null check(status_ta in ('ativo', 'inativo')),
  data_contratacao date not null,
  cargo_ta varchar(100),
  status_op varchar(20) not null check(status_op in ('ativo', 'inativo')),
  data_nascimento date,
  email_ta varchar(100)
);

create table operarios (
  cod_op int primary key not null auto_increment,
  nome_op varchar(100) not null unique,
  sal_op decimal(5,3) not null check(sal_op > 0),
  experiencia_op varchar(50) not null,
  formacao_op varchar(50) not null,
  data_contratacao date not null,
  cargo_op varchar(100),
  turno_op varchar(20),
  area_trabalho varchar(100),
  data_nascimento date,
  email_ta varchar(100)
);

create table funcao_es (
cod_funcao_es int primary key not null auto_increment,
cod_es int not null unique,
objetivo_es varchar (500),
estrategia_es varchar (500),
equipamentos_es varchar (500),
trabalhadores_es varchar (500),
materiais_es varchar (500),
portifolio_es varchar (500),
local_es varchar (500),
relacoes_es varchar (500),
foreign key (cod_es) references estrategicos(cod_es)
);

create table funcao_ta (
  cod_funcao_ta int primary key not null auto_increment,
  cod_ta int not null unique,
  projeto_ta varchar(100),
  area_responsabilidade_ta varchar(100),
  superior_direto_ta varchar(100),  
  foreign key (cod_ta) references taticos(cod_ta)
);

create table funcao_op (
  cod_funcao_op int primary key not null auto_increment,
  cod_op int not null unique,
  descricao_funcao_op varchar(500),
  ferramentas_utilizadas varchar(500),
  procedimentos varchar(500),
  riscos_ocupacionais varchar(500),
  foreign key (cod_op) references operarios(cod_op)
);

create table materiais (
    cod_mat int not null auto_increment,
    tipo_mat int not null,
    valor_mat decimal(10,2) not null,
    primary key (cod_mat)
);

create table fornecedor (
  cod_forn int primary key not null auto_increment,
  nome_forn varchar(80) not null,
  email_forn varchar(80) not null,
  cnpj_forn char(18) not null,
  cod_materiais int not null,
  status_forn varchar(20) not null check(status_forn in ('ativo', 'inativo')),
  data_cadastro date not null,
  foreign key (cod_materiais) references materiais(cod_mat)
);


create table agencias (
    cod_agencia int primary key not null auto_increment,
    nome_agencia varchar(100) not null,
    responsavel_agencia varchar(100) not null,
    data_inicio date not null,
    status_agencia varchar(20) not null check (status_agencia in ('ativa' , 'inativa')),
    email_agencia varchar(100),
    tipo_especializacao varchar(100)
);

create table contratacoes (
  cod_contrato int primary key not null auto_increment,
  cod_agencia int not null,
  cod_funcionario_op int,
  cod_funcionario_ta int,
  cod_funcionario_es int,
  data_contratacao date not null,
  cargo_contratado varchar(100) not null,
  tipo_contrato varchar(50) not null check(tipo_contrato in ('clt', 'pj', 'temporario')),
  foreign key (cod_agencia) references agencias(cod_agencia),
  foreign key (cod_funcionario_op) references operarios(cod_op),
  foreign key (cod_funcionario_ta) references taticos(cod_ta),
  foreign key (cod_funcionario_es) references estrategicos(cod_es)
  );

create table endereço_estrategicos (
  cod_endereço_es int primary key not null auto_increment,
  estado_es varchar(100) not null,
  cidade_es varchar(100) not null,
  rua_es varchar(100) not null,
  cod_es int not null unique,
  foreign key (cod_es) references estrategicos(cod_es)
);


create table endereco_tatico (
  cod_endereco_ta int primary key not null auto_increment,
  estado_ta varchar(100) not null,
  cidade_ta varchar(100) not null,
  rua_ta varchar(100) not null,
  cod_ta int not null unique,
  foreign key (cod_ta) references taticos(cod_ta)
);


create table endereco_operacional (
  cod_endereco_op int primary key not null auto_increment,
  estado_op varchar(100) not null,
  cidade_op varchar(100) not null,
  rua_op varchar(100) not null,
  cod_op int not null unique,
  foreign key (cod_op) references operarios(cod_op)
);

create table endereco_fornecedor (
  cod_endereco_forn int primary key not null auto_increment,
  estado_forn varchar(100) not null,
  cidade_forn varchar(100) not null,
  rua_forn varchar(100) not null,
  cod_forn int not null unique,
  foreign key (cod_forn) references fornecedor(cod_forn)
);
