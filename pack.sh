#!/usr/bin/env bash
tar --append -f secrets.tar appsettings.Production.json
tar --append -f secrets.tar pathwaysid_rsa
travis encrypt-file secrets.tar
