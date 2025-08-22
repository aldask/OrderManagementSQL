INSERT INTO customers (first_name, last_name, email, details)
SELECT 'FirstName' || gs AS first_name,
    'LastName' || gs AS last_name,
    'userMail' || gs || '@mail.com' AS email,
    jsonb_build_object(
        'country',
        countries [floor(random() * array_length(countries,1) + 1)::int],
        'city',
        cities [floor(random() * array_length(cities,1) + 1)::int]
    ) AS details
FROM generate_series(1, 10000) gs,
    LATERAL (
        SELECT ARRAY ['Lithuania','USA','UK','France','Latvia'] AS countries,
            ARRAY ['Kaunas','Vilnius','London', 'Washington', 'Paris','Riga'] AS cities
    );