# sovtech-test
API test
 You should develop an OpenAPI compliant API
 Your API should have 3 root paths:
 /chuck
 /swapi
 /search
 It should have an endpoint at /chuck/categories which returns the result
of https://api.chucknorris.io/jokes/categories (all the joke categories)
 It should have an endpoint at /swapi/people which returns the result of
https://swapi.dev/api/people/ (all the Star Wars people)
 Finally, the /search endpoint should call both the
https://api.chucknorris.io/jokes/search?query={query} and the
https://swapi.dev/api/people/?search={query} when queried in order to
simultaneously search both the Chuck Norris and Star Wars API. The
response should also contain metadata which indicates which API the
result belongs to.
 The /search endpoint should accept query data as a query string


# SWAGGER UI 

https://localhost:44363/swagger/index.html 


# API's 

# CHUCK 

https://localhost:44363/api/chuck/categories 


# SWAPI 

https://localhost:44363/api/swapi/people

# SEARCH 

https://localhost:44363/api/search/?query=challenging 
