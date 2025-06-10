create database pcp;
use pcp;

create table estrategicos (
  cod_es int primary key not null auto_increment,
  nome_es varchar(100) not null unique,
  email_es varchar(100),
  senha_es varchar(50),
  cpf_es char(14) not null unique,
  salario_es decimal(5,3) not null check(salario_es > 0),
  experiencia_es int not null,
  nascimento_es date,
  contratacao_es date not null
);

create table taticos (
  cod_ta int primary key not null auto_increment,
  nome_ta varchar(100) not null unique,
  email_ta varchar(100),
  senha_ta varchar(50),
  cpf_ta char(14),
  salario_ta decimal(5,3) not null check(salario_ta > 0),  
  experiencia_ta int not null,
  nascimento_ta date,
  contratacao_ta date not null
);

create table operacionais (
  cod_op int primary key not null auto_increment,
  nome_op varchar(100) not null unique,
  email_op varchar(100),
  senha_op varchar(50),
  cpf_op char(14) not null unique,
  salario_op decimal(5,3) not null check(salario_op > 0),  
  experiencia_op int not null,
  nascimento_op date,
  contratacao_op date not null
);

create table funcao_es (
  cod_funcao_es int primary key not null auto_increment,
  cod_es int not null unique,
  objetivo_es varchar(500),
  estrategia_es varchar(500),
  equipamentos_es varchar(500),
  trabalhadores_es varchar(500),
  portifolio_es varchar(500),
  local_es varchar(500),
  foreign key (cod_es) references estrategicos(cod_es)
);

create table funcao_ta (
  cod_funcao_ta int primary key not null auto_increment,
  cod_ta int not null unique,
  plano_ta varchar(500),
  lotes_ta varchar(500),
  cronograma_ta varchar(500),
  ajuste_ta varchar(500),
  desvios_ta varchar(500),
  foreign key (cod_ta) references taticos(cod_ta)
);

create table funcao_op (
  cod_funcao_op int primary key not null auto_increment,
  cod_op int not null unique,
  ordem_op varchar(500),
  progresso_op varchar(500),
  mao_obra_op varchar(500),
  ajustes_op varchar(500),
  foreign key (cod_op) references operacionais(cod_op)  
);

create table endereco_estrategicos (
  cod_endereco_es int primary key not null auto_increment,
  cod_es int not null unique,
  estado_es varchar(100) not null,
  cidade_es varchar(100) not null,
  rua_es varchar(100) not null,
  foreign key (cod_es) references estrategicos(cod_es)
);

create table endereco_taticos (
  cod_endereco_ta int primary key not null auto_increment,
  cod_ta int not null unique,
  estado_ta varchar(100) not null,
  cidade_ta varchar(100) not null,
  rua_ta varchar(100) not null,
  foreign key (cod_ta) references taticos(cod_ta)
);

create table endereco_operacionais (
  cod_endereco_op int primary key not null auto_increment,
  cod_op int not null unique,
  estado_op varchar(100) not null,
  cidade_op varchar(100) not null,
  rua_op varchar(100) not null,
  foreign key (cod_op) references operacionais(cod_op)  
);
