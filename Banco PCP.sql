create database pcp;
use pcp;

create table estrategicos (
  cod_es int primary key not null auto_increment,
  nome_es varchar(100) not null unique,
  salario_es decimal(5,3) not null check(sal_es > 0),
  experiencia_es int not null,
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
  salario_ta decimal(5,3) not null check(sal_ta > 0),
  experiencia_ta int not null,
  status_ta varchar(20) not null check(status_ta in ('ativo', 'inativo')),
  data_contratacao date not null,
  cargo_ta varchar(100),
  data_nascimento date,
  email_ta varchar(100)
);

create table operacionais (
  cod_op int primary key not null auto_increment,
  nome_op varchar(100) not null unique,
  salario_op decimal(5,3) not null check(sal_op > 0),
  experiencia_op int not null,
  status_op varchar(20) not null check(status_op in ('ativo', 'inativo')),
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
portifolio_es varchar (500),
local_es varchar (500),
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
  foreign key (cod_op) references operarios(cod_op)
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
