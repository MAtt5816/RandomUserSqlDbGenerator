CREATE DATABASE IF NOT EXISTS user_data;
USE user_data;

CREATE TABLE users
(
    id             INT AUTO_INCREMENT PRIMARY KEY,
    gender         VARCHAR(10),
    title          VARCHAR(10),
    first_name     VARCHAR(50),
    last_name      VARCHAR(50),
    email          VARCHAR(100),
    dob            DATE,
    age            INT,
    registered     DATE,
    registered_age INT,
    phone          VARCHAR(20),
    cell           VARCHAR(20),
    id_name        VARCHAR(20),
    id_value       VARCHAR(50),
    nat            VARCHAR(10)
);

CREATE TABLE locations
(
    user_id              INT,
    street_number        INT,
    street_name          VARCHAR(100),
    city                 VARCHAR(100),
    state                VARCHAR(100),
    country              VARCHAR(100),
    postcode             VARCHAR(20),
    latitude             DECIMAL(9, 6),
    longitude            DECIMAL(9, 6),
    timezone_offset      VARCHAR(10),
    timezone_description VARCHAR(100),
    FOREIGN KEY (user_id) REFERENCES users (id)
);

CREATE TABLE logins
(
    user_id  INT,
    uuid     VARCHAR(36),
    username VARCHAR(50),
    password VARCHAR(100),
    salt     VARCHAR(20),
    md5      VARCHAR(32),
    sha1     VARCHAR(40),
    sha256   VARCHAR(64),
    FOREIGN KEY (user_id) REFERENCES users (id)
);

CREATE TABLE pictures
(
    user_id   INT,
    large     VARCHAR(255),
    medium    VARCHAR(255),
    thumbnail VARCHAR(255),
    FOREIGN KEY (user_id) REFERENCES users (id)
);
