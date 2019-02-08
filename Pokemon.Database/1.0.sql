﻿CREATE TABLE Contact
(
  id int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(250) NOT NULL,
  email VARCHAR(250) NOT NULL,
  subject VARCHAR(250) NOT NULL,
  message TEXT NOT NULL
);

CREATE TABLE ErrorEmail
(
	id int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
	name VARCHAR(250) NOT NULL,
	email VARCHAR(250) NOT NULL,
	send bit(1) default false
);