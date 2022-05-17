--
-- PostgreSQL database dump
--

-- Dumped from database version 13.3
-- Dumped by pg_dump version 13.3

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: contents; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.contents (
    id integer NOT NULL,
    user_id integer NOT NULL,
    title character varying(100) NOT NULL,
    slug character varying(100),
    description character varying,
    photos character varying(300),
    created_at date
);


ALTER TABLE public.contents OWNER TO postgres;

--
-- Name: contents_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.contents_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.contents_id_seq OWNER TO postgres;

--
-- Name: contents_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.contents_id_seq OWNED BY public.contents.id;


--
-- Name: operation_claims; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.operation_claims (
    id integer NOT NULL,
    name character varying(250) NOT NULL
);


ALTER TABLE public.operation_claims OWNER TO postgres;

--
-- Name: operation_claims_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.operation_claims_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.operation_claims_id_seq OWNER TO postgres;

--
-- Name: operation_claims_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.operation_claims_id_seq OWNED BY public.operation_claims.id;


--
-- Name: user_operation_claims; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.user_operation_claims (
    id integer NOT NULL,
    user_id integer NOT NULL,
    operation_claim_id integer NOT NULL
);


ALTER TABLE public.user_operation_claims OWNER TO postgres;

--
-- Name: user_operation_claims_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.user_operation_claims_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.user_operation_claims_id_seq OWNER TO postgres;

--
-- Name: user_operation_claims_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.user_operation_claims_id_seq OWNED BY public.user_operation_claims.id;


--
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    id integer NOT NULL,
    name character varying(20),
    email character varying(60),
    username character varying(25),
    description character varying(250),
    picture_path character varying(400),
    password_hash bytea,
    password_salt bytea
);


ALTER TABLE public.users OWNER TO postgres;

--
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.users_id_seq OWNER TO postgres;

--
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;


--
-- Name: contents id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contents ALTER COLUMN id SET DEFAULT nextval('public.contents_id_seq'::regclass);


--
-- Name: operation_claims id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.operation_claims ALTER COLUMN id SET DEFAULT nextval('public.operation_claims_id_seq'::regclass);


--
-- Name: user_operation_claims id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.user_operation_claims ALTER COLUMN id SET DEFAULT nextval('public.user_operation_claims_id_seq'::regclass);


--
-- Name: users id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);


--
-- Data for Name: contents; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.contents (id, user_id, title, slug, description, photos, created_at) FROM stdin;
5	3	Üstel Fonksiyonunun Türevi	üstel_fonksiyonunun_türevi	 y=e^x ise y'=e^x y=e^u ise y'=u'.e^u	exp.png:derivation.png	2022-04-21
6	5	Üstel Fonksiyonunun Türevi	üstel_fonksiyonunun_türevi	 y=e^x ise y'=e^x y=e^u ise y'=u'.e^u	exp.png:derivation.png	2022-04-22
4	1	Üstel Fonksiyonunun Logaritması	üstel_fonksiyonunun_türevi	 y=e^x ise y'=e^x y=e^u ise y'=u'.e^u	exp.png:derivation.png	2022-04-21
3	1	Logaritma Fonksiyonunun Kuvveti	logaritma_fonksiyonunun_türevi	string	exp.png:derivation.png:ln.png	2022-04-21
\.


--
-- Data for Name: operation_claims; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.operation_claims (id, name) FROM stdin;
1	Admin
2	Moderatör
3	Üye
\.


--
-- Data for Name: user_operation_claims; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.user_operation_claims (id, user_id, operation_claim_id) FROM stdin;
1	1	1
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (id, name, email, username, description, picture_path, password_hash, password_salt) FROM stdin;
1	Kadir Mert Yıldız	kadir@kadir.com	kadirov	\N	C:\\ProfileImages\\1.jpg	\\x5cc46cadc11678644dd8cdda7e4b5c4d0db1d80e593a4c04c3e212659c30b1a6c9830b3c6e58aa03440c0e71d86f5aca95a9e7006028b58752d3cc74e727e9e3	\\x6b54ffe8be042d118d6ff8fbb13bf24f9e5d4280581575825666dacb9d62213b35ab6d3bfaaca72542415ccfffbd2ce1bf67bf4b5aad99bb35a90f8c912c99ade670a787f9483b4cd50037e60910a55738d4772c44b4d411ae991372dfd0fb147bc6964b76ccbdca365c2282b1b3365b58aa0c70ad280ed9090096aef82fab95
\.


--
-- Name: contents_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.contents_id_seq', 6, true);


--
-- Name: operation_claims_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.operation_claims_id_seq', 3, true);


--
-- Name: user_operation_claims_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.user_operation_claims_id_seq', 1, true);


--
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_seq', 1, true);


--
-- Name: contents contents_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contents
    ADD CONSTRAINT contents_pk PRIMARY KEY (id);


--
-- Name: operation_claims operation_claims_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.operation_claims
    ADD CONSTRAINT operation_claims_pkey PRIMARY KEY (id);


--
-- Name: user_operation_claims user_operation_claims_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.user_operation_claims
    ADD CONSTRAINT user_operation_claims_pkey PRIMARY KEY (id);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- PostgreSQL database dump complete
--

