ARG := $(word 2, $(MAKECMDGOALS))


%:
	@:

up:
	@docker compose up 

rebuild:
	@docker compose build

stop:
	@docker compose stop

reload:
	@if [ "${ARG}" = 'core' ] || [ "${ARG}" = 'c' ] || [ "${ARG}" = '' ]; then docker compose restart api; fi
	@if [ "${ARG}" = 'identity' ] || [ "${ARG}" = 'i' ]; then docker compose restart server; fi