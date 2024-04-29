CREATE DATABASE IF NOT EXISTS unityservices;

USE unityservices;

CREATE TABLE IF NOT EXISTS ranking
(
    id INT NOT NULL AUTO_INCREMENT,
    nome VARCHAR(30) NOT NULL,
    pontuacao INT NOT NULL,
    PRIMARY KEY(id)
);