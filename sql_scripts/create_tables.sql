use episodeum;

create table if not exists age_limit(
	id int primary key auto_increment,
	age int not null unique
);

create table if not exists genre(
	id int primary key auto_increment,
	name varchar(30) not null unique
);

create table if not exists contribution(
	id int primary key auto_increment,
	name varchar(30) not null unique
);

create table if not exists country(
	id int primary key auto_increment,
	name varchar(100),
	nationality varchar(100)
);

create table if not exists gender (
	id int primary key auto_increment,
    name varchar(30) not null unique
);

create table if not exists person(
	id int primary key auto_increment,
	first_name varchar(100) not null,
	surname varchar(100) not null,
	gender_id int not null,
	birth_date date,
	country_id int,
	constraint fk_person_country foreign key (country_id) references country(id),
	constraint fk_person_gender foreign key (gender_id) references gender(id)
);

create table if not exists series (
	id int primary key auto_increment,
	imdb_id varchar(9) check(imdb_id like 'tt%'),
    title varchar(100) not null,
	age_limit_id int not null, 
    genre_id int not null,
	is_on_program boolean,
	show_time datetime,
	view_number int check (view_number >= 0),
	country_id int not null,
	constraint fk_series_country foreign key (country_id) references country(id),
	constraint fk_series_age_limit foreign key (age_limit_id) references age_limit(id),
	constraint fk_series_genre foreign key (genre_id) references genre(id)
);

create table if not exists person_to_series(
	id int primary key auto_increment,
	person_id int not null,
	series_id int not null,
	contribution_id int not null,
	constraint fk_person_to_series_series foreign key (series_id) references series(id),
	constraint fk_person_to_series_person foreign key (person_id) references person(id),
	constraint fk_person_to_series_contribution foreign key (contribution_id) references contribution(id)
);
