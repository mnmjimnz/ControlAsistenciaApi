--
-- PostgreSQL database dump
--

\restrict H5QOmgbXeQQSGnAID6kfZCJQXjYuZhPEhdxMrfWJ7lnn247IlpjM0ifR1rmwYKO

-- Dumped from database version 18.3 (Debian 18.3-1.pgdg12+1)
-- Dumped by pg_dump version 18.2

-- Started on 2026-05-27 00:31:15

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 5 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: admin
--

-- *not* creating schema, since initdb creates it


ALTER SCHEMA public OWNER TO admin;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 224 (class 1259 OID 16416)
-- Name: alumno; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.alumno (
    id integer NOT NULL,
    nombre character varying(100) NOT NULL,
    apellido character varying(100) NOT NULL,
    carrera character varying(150)
);


ALTER TABLE public.alumno OWNER TO admin;

--
-- TOC entry 223 (class 1259 OID 16415)
-- Name: alumno_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.alumno_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.alumno_id_seq OWNER TO admin;

--
-- TOC entry 3442 (class 0 OID 0)
-- Dependencies: 223
-- Name: alumno_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.alumno_id_seq OWNED BY public.alumno.id;


--
-- TOC entry 222 (class 1259 OID 16408)
-- Name: aula; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.aula (
    id integer NOT NULL,
    codigo character varying(15)
);


ALTER TABLE public.aula OWNER TO admin;

--
-- TOC entry 221 (class 1259 OID 16407)
-- Name: aula_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.aula_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.aula_id_seq OWNER TO admin;

--
-- TOC entry 3443 (class 0 OID 0)
-- Dependencies: 221
-- Name: aula_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.aula_id_seq OWNED BY public.aula.id;


--
-- TOC entry 228 (class 1259 OID 16447)
-- Name: horario_d; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.horario_d (
    id integer NOT NULL,
    idalumno integer NOT NULL,
    idhorario_h integer NOT NULL
);


ALTER TABLE public.horario_d OWNER TO admin;

--
-- TOC entry 227 (class 1259 OID 16446)
-- Name: horario_d_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.horario_d_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.horario_d_id_seq OWNER TO admin;

--
-- TOC entry 3444 (class 0 OID 0)
-- Dependencies: 227
-- Name: horario_d_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.horario_d_id_seq OWNED BY public.horario_d.id;


--
-- TOC entry 226 (class 1259 OID 16426)
-- Name: horario_h; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.horario_h (
    id integer NOT NULL,
    idaula integer NOT NULL,
    idmateria integer NOT NULL,
    hora_inicio character varying(10),
    hora_fin character varying(10),
    fecha character varying(30),
    catedratico character varying(100) NOT NULL,
    grupo character varying(50),
    ciclo character varying(10),
    diasemana character varying(50)
);


ALTER TABLE public.horario_h OWNER TO admin;

--
-- TOC entry 225 (class 1259 OID 16425)
-- Name: horario_h_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.horario_h_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.horario_h_id_seq OWNER TO admin;

--
-- TOC entry 3445 (class 0 OID 0)
-- Dependencies: 225
-- Name: horario_h_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.horario_h_id_seq OWNED BY public.horario_h.id;


--
-- TOC entry 220 (class 1259 OID 16399)
-- Name: materia; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.materia (
    id integer NOT NULL,
    nombre character varying(150) NOT NULL
);


ALTER TABLE public.materia OWNER TO admin;

--
-- TOC entry 219 (class 1259 OID 16398)
-- Name: materia_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.materia_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.materia_id_seq OWNER TO admin;

--
-- TOC entry 3446 (class 0 OID 0)
-- Dependencies: 219
-- Name: materia_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.materia_id_seq OWNED BY public.materia.id;


--
-- TOC entry 230 (class 1259 OID 16467)
-- Name: registro_asistencia; Type: TABLE; Schema: public; Owner: admin
--

CREATE TABLE public.registro_asistencia (
    id integer NOT NULL,
    id_horario_d integer NOT NULL,
    estado boolean,
    fecha character varying(30),
    id_horario_h integer,
    fingerprint_sha256 character varying(255),
    ip character varying(100),
    user_agent text,
    token_jti character varying(500)
);


ALTER TABLE public.registro_asistencia OWNER TO admin;

--
-- TOC entry 229 (class 1259 OID 16466)
-- Name: registro_asistencia_id_seq; Type: SEQUENCE; Schema: public; Owner: admin
--

CREATE SEQUENCE public.registro_asistencia_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.registro_asistencia_id_seq OWNER TO admin;

--
-- TOC entry 3447 (class 0 OID 0)
-- Dependencies: 229
-- Name: registro_asistencia_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: admin
--

ALTER SEQUENCE public.registro_asistencia_id_seq OWNED BY public.registro_asistencia.id;


--
-- TOC entry 3256 (class 2604 OID 16419)
-- Name: alumno id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.alumno ALTER COLUMN id SET DEFAULT nextval('public.alumno_id_seq'::regclass);


--
-- TOC entry 3255 (class 2604 OID 16411)
-- Name: aula id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.aula ALTER COLUMN id SET DEFAULT nextval('public.aula_id_seq'::regclass);


--
-- TOC entry 3258 (class 2604 OID 16450)
-- Name: horario_d id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.horario_d ALTER COLUMN id SET DEFAULT nextval('public.horario_d_id_seq'::regclass);


--
-- TOC entry 3257 (class 2604 OID 16429)
-- Name: horario_h id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.horario_h ALTER COLUMN id SET DEFAULT nextval('public.horario_h_id_seq'::regclass);


--
-- TOC entry 3254 (class 2604 OID 16402)
-- Name: materia id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.materia ALTER COLUMN id SET DEFAULT nextval('public.materia_id_seq'::regclass);


--
-- TOC entry 3259 (class 2604 OID 16470)
-- Name: registro_asistencia id; Type: DEFAULT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.registro_asistencia ALTER COLUMN id SET DEFAULT nextval('public.registro_asistencia_id_seq'::regclass);


--
-- TOC entry 3430 (class 0 OID 16416)
-- Dependencies: 224
-- Data for Name: alumno; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public.alumno VALUES (11, 'Juan', 'Perez', 'Psicologia');
INSERT INTO public.alumno VALUES (12, 'Pablo', 'Marmol', 'Ing Agronegocios');
INSERT INTO public.alumno VALUES (13, 'Pedro', 'Picapiedra', 'Ing Industrial');
INSERT INTO public.alumno VALUES (14, 'Vilma', 'Picapiedra', 'Ing Sistemas');
INSERT INTO public.alumno VALUES (15, 'Betty', 'Marmol', 'Lic Mercadeo');
INSERT INTO public.alumno VALUES (16, 'Vegeta', '', 'Cocina');


--
-- TOC entry 3428 (class 0 OID 16408)
-- Dependencies: 222
-- Data for Name: aula; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public.aula VALUES (11, 'C-11');
INSERT INTO public.aula VALUES (12, 'C-3');
INSERT INTO public.aula VALUES (13, 'A-22');
INSERT INTO public.aula VALUES (14, 'A-33');
INSERT INTO public.aula VALUES (16, 'B-01');
INSERT INTO public.aula VALUES (17, 'C-33');
INSERT INTO public.aula VALUES (15, 'A-02');


--
-- TOC entry 3434 (class 0 OID 16447)
-- Dependencies: 228
-- Data for Name: horario_d; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public.horario_d VALUES (111, 14, 12);
INSERT INTO public.horario_d VALUES (112, 12, 12);
INSERT INTO public.horario_d VALUES (113, 12, 14);
INSERT INTO public.horario_d VALUES (114, 15, 14);
INSERT INTO public.horario_d VALUES (115, 16, 14);
INSERT INTO public.horario_d VALUES (116, 14, 14);
INSERT INTO public.horario_d VALUES (117, 11, 11);
INSERT INTO public.horario_d VALUES (118, 13, 11);
INSERT INTO public.horario_d VALUES (119, 14, 11);
INSERT INTO public.horario_d VALUES (120, 15, 11);
INSERT INTO public.horario_d VALUES (121, 12, 15);
INSERT INTO public.horario_d VALUES (122, 13, 15);
INSERT INTO public.horario_d VALUES (124, 15, 15);
INSERT INTO public.horario_d VALUES (125, 11, 10);
INSERT INTO public.horario_d VALUES (126, 14, 10);
INSERT INTO public.horario_d VALUES (127, 15, 10);
INSERT INTO public.horario_d VALUES (128, 13, 16);
INSERT INTO public.horario_d VALUES (129, 11, 15);
INSERT INTO public.horario_d VALUES (130, 12, 16);
INSERT INTO public.horario_d VALUES (131, 14, 16);
INSERT INTO public.horario_d VALUES (132, 15, 16);
INSERT INTO public.horario_d VALUES (133, 11, 16);
INSERT INTO public.horario_d VALUES (134, 11, 13);
INSERT INTO public.horario_d VALUES (135, 11, 12);
INSERT INTO public.horario_d VALUES (136, 13, 12);
INSERT INTO public.horario_d VALUES (137, 16, 12);


--
-- TOC entry 3432 (class 0 OID 16426)
-- Dependencies: 226
-- Data for Name: horario_h; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public.horario_h VALUES (13, 16, 13, '13:00', '15:30', '2026', 'Galileo Galilei', 'G07', '01', 'lunes');
INSERT INTO public.horario_h VALUES (10, 11, 7, '08:00', '10:30', '2026', 'Albert Einstein', 'G02', '01', 'martes');
INSERT INTO public.horario_h VALUES (14, 12, 10, '18:00', '20:30', '2026', 'Juan', '03', '01', 'viernes');
INSERT INTO public.horario_h VALUES (12, 13, 9, '07:00', '09:30', '2026', 'Nicola Tesla', 'G04', '02', 'viernes');
INSERT INTO public.horario_h VALUES (11, 12, 8, '09:00', '11:00', '2026', 'Issac Newton', 'G01', '02', 'viernes');
INSERT INTO public.horario_h VALUES (15, 13, 11, '08:00', '10:30', '2026', 'Dino', '01', '02', 'sabado');
INSERT INTO public.horario_h VALUES (16, 13, 7, '12:30', '03:00', '2026', 'Richard Parker', '02', '02', 'sabado');


--
-- TOC entry 3426 (class 0 OID 16399)
-- Dependencies: 220
-- Data for Name: materia; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public.materia VALUES (7, 'Matematica I');
INSERT INTO public.materia VALUES (8, 'Bases de datos I');
INSERT INTO public.materia VALUES (9, 'Fisica I');
INSERT INTO public.materia VALUES (10, 'Contabilidad');
INSERT INTO public.materia VALUES (11, 'Programacion I');
INSERT INTO public.materia VALUES (12, 'Redes de Computadoras');
INSERT INTO public.materia VALUES (13, 'Algebra de Vectores');


--
-- TOC entry 3436 (class 0 OID 16467)
-- Dependencies: 230
-- Data for Name: registro_asistencia; Type: TABLE DATA; Schema: public; Owner: admin
--

INSERT INTO public.registro_asistencia VALUES (60, 122, true, '02/05/2026', 15, 'ef2b1e419c9d888e238aab3c2e301958e3503ed767e1a2d7be84b67f68cc45cb', NULL, 'Mozilla/5.0 (Linux; Android 10; K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/148.0.0.0 Mobile Safari/537.36', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZEhvcmFyaW9IIjoiMTUiLCJ0aXBvIjoiUVJfQVNJU1RFTkNJQSIsImV4cCI6MTc3OTQxNDAzOCwiaXNzIjoiQXNpc3RlbmNpYUFwcCIsImF1ZCI6IkFzaXN0ZW5jaWFBcHBVc2VycyJ9.vH9rzXZu1FDmbAvNuVkLJZDwa0BCxmeEw2dJP0hRrYw');
INSERT INTO public.registro_asistencia VALUES (61, 128, true, '02/05/2026', 16, 'ef2b1e419c9d888e238aab3c2e301958e3503ed767e1a2d7be84b67f68cc45cb', NULL, 'Mozilla/5.0 (Linux; Android 10; K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/148.0.0.0 Mobile Safari/537.36', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZEhvcmFyaW9IIjoiMTYiLCJ0aXBvIjoiUVJfQVNJU1RFTkNJQSIsImV4cCI6MTc3OTQxNDA3MSwiaXNzIjoiQXNpc3RlbmNpYUFwcCIsImF1ZCI6IkFzaXN0ZW5jaWFBcHBVc2VycyJ9._v1Z61TB0ZB5--wZm0XqSIfYh7l-wTYNn1D7aWCvg_Q');
INSERT INTO public.registro_asistencia VALUES (62, 126, true, '05/05/2026', 10, 'ef2b1e419c9d888e238aab3c2e301958e3503ed767e1a2d7be84b67f68cc45cb', NULL, 'Mozilla/5.0 (Linux; Android 10; K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/148.0.0.0 Mobile Safari/537.36', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZEhvcmFyaW9IIjoiMTAiLCJ0aXBvIjoiUVJfQVNJU1RFTkNJQSIsImV4cCI6MTc3OTQzMDQzMiwiaXNzIjoiQXNpc3RlbmNpYUFwcCIsImF1ZCI6IkFzaXN0ZW5jaWFBcHBVc2VycyJ9.VRPC_xsUerP5cV7r6aDUWe1ynK2Z0qxPSUGY_nVPyXY');
INSERT INTO public.registro_asistencia VALUES (69, 126, true, '12/05/2026', 10, 'edcec3a6aef33e3dbc49a20e44907765fd506405971840bf839a0c83421a9eb4', NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:151.0) Gecko/20100101 Firefox/151.0', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZEhvcmFyaW9IIjoiMTAiLCJ0aXBvIjoiUVJfQVNJU1RFTkNJQSIsImV4cCI6MTc3OTQzMDQ5MSwiaXNzIjoiQXNpc3RlbmNpYUFwcCIsImF1ZCI6IkFzaXN0ZW5jaWFBcHBVc2VycyJ9.Kfn3K_oSw1dzclam8NpYpsI-7J0qQnRsaMdgdnh3kzs');
INSERT INTO public.registro_asistencia VALUES (74, 126, true, '26/05/2026', 10, 'edcec3a6aef33e3dbc49a20e44907765fd506405971840bf839a0c83421a9eb4', NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:151.0) Gecko/20100101 Firefox/151.0', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZEhvcmFyaW9IIjoiMTAiLCJ0aXBvIjoiUVJfQVNJU1RFTkNJQSIsImV4cCI6MTc3OTQzMTEyNSwiaXNzIjoiQXNpc3RlbmNpYUFwcCIsImF1ZCI6IkFzaXN0ZW5jaWFBcHBVc2VycyJ9.ZHhEOwJVu5HKN8xuh4kWJ-Kcq9bslNbHQ_9lUoPPipI');
INSERT INTO public.registro_asistencia VALUES (75, 113, true, '08/05/2026', 14, 'edcec3a6aef33e3dbc49a20e44907765fd506405971840bf839a0c83421a9eb4', NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:151.0) Gecko/20100101 Firefox/151.0', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZEhvcmFyaW9IIjoiMTQiLCJ0aXBvIjoiUVJfQVNJU1RFTkNJQSIsImV4cCI6MTc3OTQzMTIzOSwiaXNzIjoiQXNpc3RlbmNpYUFwcCIsImF1ZCI6IkFzaXN0ZW5jaWFBcHBVc2VycyJ9.o9d0gYN-DlKdNFiup5V0FJxxCAUp_-QL7OZaDDKrRcw');
INSERT INTO public.registro_asistencia VALUES (76, 113, true, '15/05/2026', 14, 'edcec3a6aef33e3dbc49a20e44907765fd506405971840bf839a0c83421a9eb4', NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:151.0) Gecko/20100101 Firefox/151.0', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZEhvcmFyaW9IIjoiMTQiLCJ0aXBvIjoiUVJfQVNJU1RFTkNJQSIsImV4cCI6MTc3OTQzMTI5OCwiaXNzIjoiQXNpc3RlbmNpYUFwcCIsImF1ZCI6IkFzaXN0ZW5jaWFBcHBVc2VycyJ9.0R-KwqwWzUkyXLQNvUhx3kfAbentXQYmMUF1oTQ7QSw');
INSERT INTO public.registro_asistencia VALUES (77, 115, true, '29/05/2026', 14, 'edcec3a6aef33e3dbc49a20e44907765fd506405971840bf839a0c83421a9eb4', NULL, 'Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:151.0) Gecko/20100101 Firefox/151.0', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZEhvcmFyaW9IIjoiMTQiLCJ0aXBvIjoiUVJfQVNJU1RFTkNJQSIsImV4cCI6MTc3OTQzMTMzNSwiaXNzIjoiQXNpc3RlbmNpYUFwcCIsImF1ZCI6IkFzaXN0ZW5jaWFBcHBVc2VycyJ9.FliLjgHD1O3g4VcMsCcuY8Ywh1gyfrxJUrpqFWdo4CE');
INSERT INTO public.registro_asistencia VALUES (78, 115, true, '01/05/2026', 14, 'ef2b1e419c9d888e238aab3c2e301958e3503ed767e1a2d7be84b67f68cc45cb', NULL, 'Mozilla/5.0 (Linux; Android 10; K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/148.0.0.0 Mobile Safari/537.36', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZEhvcmFyaW9IIjoiMTQiLCJ0aXBvIjoiUVJfQVNJU1RFTkNJQSIsImV4cCI6MTc3OTQzMTU4OCwiaXNzIjoiQXNpc3RlbmNpYUFwcCIsImF1ZCI6IkFzaXN0ZW5jaWFBcHBVc2VycyJ9.Rg7GUiPwxZvSBKqMCdab9RTCy2clBSkQMA_zMmIAHL0');
INSERT INTO public.registro_asistencia VALUES (79, 115, true, '08/05/2026', 14, 'ef2b1e419c9d888e238aab3c2e301958e3503ed767e1a2d7be84b67f68cc45cb', NULL, 'Mozilla/5.0 (Linux; Android 10; K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/148.0.0.0 Mobile Safari/537.36', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZEhvcmFyaW9IIjoiMTQiLCJ0aXBvIjoiUVJfQVNJU1RFTkNJQSIsImV4cCI6MTc3OTQzMTY4MSwiaXNzIjoiQXNpc3RlbmNpYUFwcCIsImF1ZCI6IkFzaXN0ZW5jaWFBcHBVc2VycyJ9.SCrtb9hg42Yl1AiMDh8Qe_ejijKHVeRvp7SmWhTtxes');
INSERT INTO public.registro_asistencia VALUES (80, 115, true, '15/05/2026', 14, 'ef2b1e419c9d888e238aab3c2e301958e3503ed767e1a2d7be84b67f68cc45cb', NULL, 'Mozilla/5.0 (Linux; Android 10; K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/148.0.0.0 Mobile Safari/537.36', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZEhvcmFyaW9IIjoiMTQiLCJ0aXBvIjoiUVJfQVNJU1RFTkNJQSIsImV4cCI6MTc3OTQzMTY5OSwiaXNzIjoiQXNpc3RlbmNpYUFwcCIsImF1ZCI6IkFzaXN0ZW5jaWFBcHBVc2VycyJ9.6yF91U9l0jI4RNBreB7DkHMZPlQOyUmYXF7VyqFQ1Pg');
INSERT INTO public.registro_asistencia VALUES (82, 115, true, '29/05/2026', 14, 'ef2b1e419c9d888e238aab3c2e301958e3503ed767e1a2d7be84b67f68cc45cb', NULL, 'Mozilla/5.0 (Linux; Android 10; K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/148.0.0.0 Mobile Safari/537.36', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZEhvcmFyaW9IIjoiMTQiLCJ0aXBvIjoiUVJfQVNJU1RFTkNJQSIsImV4cCI6MTc3OTQzMTc0MiwiaXNzIjoiQXNpc3RlbmNpYUFwcCIsImF1ZCI6IkFzaXN0ZW5jaWFBcHBVc2VycyJ9.sM6qL-V8r9bYvZVn8YYYuA0Uu7lnPKnFKg0naKe8NsI');
INSERT INTO public.registro_asistencia VALUES (81, 115, true, '22/05/2026', 14, 'ef2b1e419c9d888e238aab3c2e301958e3503ed767e1a2d7be84b67f68cc45cb', NULL, 'Mozilla/5.0 (Linux; Android 10; K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/148.0.0.0 Mobile Safari/537.36', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZEhvcmFyaW9IIjoiMTQiLCJ0aXBvIjoiUVJfQVNJU1RFTkNJQSIsImV4cCI6MTc3OTQzMTcyNiwiaXNzIjoiQXNpc3RlbmNpYUFwcCIsImF1ZCI6IkFzaXN0ZW5jaWFBcHBVc2VycyJ9.Rt4jm4Ysh_kcqJSHIh0ty1Yjv5ufKvhPOKUjFB9fjXM');
INSERT INTO public.registro_asistencia VALUES (83, 125, true, '05/05/2026', 10, 'ef2b1e419c9d888e238aab3c2e301958e3503ed767e1a2d7be84b67f68cc45cb', NULL, 'Mozilla/5.0 (Linux; Android 10; K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/148.0.0.0 Mobile Safari/537.36', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZEhvcmFyaW9IIjoiMTAiLCJ0aXBvIjoiUVJfQVNJU1RFTkNJQSIsImV4cCI6MTc3OTQzMTc2MSwiaXNzIjoiQXNpc3RlbmNpYUFwcCIsImF1ZCI6IkFzaXN0ZW5jaWFBcHBVc2VycyJ9.qO90V-HVqfMib6rOxR9jzTazFQpWj3yIBk8PIqCmGXY');
INSERT INTO public.registro_asistencia VALUES (84, 134, true, '18/05/2026', 13, 'ef2b1e419c9d888e238aab3c2e301958e3503ed767e1a2d7be84b67f68cc45cb', NULL, 'Mozilla/5.0 (Linux; Android 10; K) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/148.0.0.0 Mobile Safari/537.36', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZEhvcmFyaW9IIjoiMTMiLCJ0aXBvIjoiUVJfQVNJU1RFTkNJQSIsImV4cCI6MTc3OTQzMTgyNywiaXNzIjoiQXNpc3RlbmNpYUFwcCIsImF1ZCI6IkFzaXN0ZW5jaWFBcHBVc2VycyJ9.lwiWC4uTre1bWDHPY4c93vfHVEbKg_CAhMU3_q8AmAY');


--
-- TOC entry 3448 (class 0 OID 0)
-- Dependencies: 223
-- Name: alumno_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.alumno_id_seq', 16, true);


--
-- TOC entry 3449 (class 0 OID 0)
-- Dependencies: 221
-- Name: aula_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.aula_id_seq', 17, true);


--
-- TOC entry 3450 (class 0 OID 0)
-- Dependencies: 227
-- Name: horario_d_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.horario_d_id_seq', 137, true);


--
-- TOC entry 3451 (class 0 OID 0)
-- Dependencies: 225
-- Name: horario_h_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.horario_h_id_seq', 16, true);


--
-- TOC entry 3452 (class 0 OID 0)
-- Dependencies: 219
-- Name: materia_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.materia_id_seq', 13, true);


--
-- TOC entry 3453 (class 0 OID 0)
-- Dependencies: 229
-- Name: registro_asistencia_id_seq; Type: SEQUENCE SET; Schema: public; Owner: admin
--

SELECT pg_catalog.setval('public.registro_asistencia_id_seq', 84, true);


--
-- TOC entry 3265 (class 2606 OID 16424)
-- Name: alumno alumno_pkey; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.alumno
    ADD CONSTRAINT alumno_pkey PRIMARY KEY (id);


--
-- TOC entry 3263 (class 2606 OID 16414)
-- Name: aula aula_pkey; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.aula
    ADD CONSTRAINT aula_pkey PRIMARY KEY (id);


--
-- TOC entry 3269 (class 2606 OID 16455)
-- Name: horario_d horario_d_pkey; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.horario_d
    ADD CONSTRAINT horario_d_pkey PRIMARY KEY (id);


--
-- TOC entry 3267 (class 2606 OID 16435)
-- Name: horario_h horario_h_pkey; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.horario_h
    ADD CONSTRAINT horario_h_pkey PRIMARY KEY (id);


--
-- TOC entry 3261 (class 2606 OID 16406)
-- Name: materia materia_pkey; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.materia
    ADD CONSTRAINT materia_pkey PRIMARY KEY (id);


--
-- TOC entry 3271 (class 2606 OID 16474)
-- Name: registro_asistencia registro_asistencia_pkey; Type: CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.registro_asistencia
    ADD CONSTRAINT registro_asistencia_pkey PRIMARY KEY (id);


--
-- TOC entry 3276 (class 2606 OID 16502)
-- Name: registro_asistencia fk_registro_asistencia_horario_h; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.registro_asistencia
    ADD CONSTRAINT fk_registro_asistencia_horario_h FOREIGN KEY (id_horario_h) REFERENCES public.horario_h(id);


--
-- TOC entry 3274 (class 2606 OID 16456)
-- Name: horario_d horario_d_idalumno_fkey; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.horario_d
    ADD CONSTRAINT horario_d_idalumno_fkey FOREIGN KEY (idalumno) REFERENCES public.alumno(id);


--
-- TOC entry 3275 (class 2606 OID 16461)
-- Name: horario_d horario_d_idhorario_h_fkey; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.horario_d
    ADD CONSTRAINT horario_d_idhorario_h_fkey FOREIGN KEY (idhorario_h) REFERENCES public.horario_h(id);


--
-- TOC entry 3272 (class 2606 OID 16436)
-- Name: horario_h horario_h_idaula_fkey; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.horario_h
    ADD CONSTRAINT horario_h_idaula_fkey FOREIGN KEY (idaula) REFERENCES public.aula(id);


--
-- TOC entry 3273 (class 2606 OID 16441)
-- Name: horario_h horario_h_idmateria_fkey; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.horario_h
    ADD CONSTRAINT horario_h_idmateria_fkey FOREIGN KEY (idmateria) REFERENCES public.materia(id);


--
-- TOC entry 3277 (class 2606 OID 16475)
-- Name: registro_asistencia registro_asistencia_id_horario_d_fkey; Type: FK CONSTRAINT; Schema: public; Owner: admin
--

ALTER TABLE ONLY public.registro_asistencia
    ADD CONSTRAINT registro_asistencia_id_horario_d_fkey FOREIGN KEY (id_horario_d) REFERENCES public.horario_d(id);


--
-- TOC entry 2078 (class 826 OID 16391)
-- Name: DEFAULT PRIVILEGES FOR SEQUENCES; Type: DEFAULT ACL; Schema: -; Owner: postgres
--

ALTER DEFAULT PRIVILEGES FOR ROLE postgres GRANT ALL ON SEQUENCES TO admin;


--
-- TOC entry 2080 (class 826 OID 16393)
-- Name: DEFAULT PRIVILEGES FOR TYPES; Type: DEFAULT ACL; Schema: -; Owner: postgres
--

ALTER DEFAULT PRIVILEGES FOR ROLE postgres GRANT ALL ON TYPES TO admin;


--
-- TOC entry 2079 (class 826 OID 16392)
-- Name: DEFAULT PRIVILEGES FOR FUNCTIONS; Type: DEFAULT ACL; Schema: -; Owner: postgres
--

ALTER DEFAULT PRIVILEGES FOR ROLE postgres GRANT ALL ON FUNCTIONS TO admin;


--
-- TOC entry 2077 (class 826 OID 16390)
-- Name: DEFAULT PRIVILEGES FOR TABLES; Type: DEFAULT ACL; Schema: -; Owner: postgres
--

ALTER DEFAULT PRIVILEGES FOR ROLE postgres GRANT ALL ON TABLES TO admin;


-- Completed on 2026-05-27 00:31:30

--
-- PostgreSQL database dump complete
--

\unrestrict H5QOmgbXeQQSGnAID6kfZCJQXjYuZhPEhdxMrfWJ7lnn247IlpjM0ifR1rmwYKO

