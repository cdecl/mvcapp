#!/bin/bash

# rm -rf Publish/ubuntu-20.04
# dotnet publish -c Release -o Publish/ubuntu-20.04

if [ ! -z "$1" ] && [ $1 == "docker" ]; then
	printf 'input version: '
	read -r ver

	printf 'cdecl/mvcapp:%s [y/N]: ' $ver
	read -r yn

	if [ ! -z "$yn" ] && [ $yn == "y" ]; then
		docker build . -t cdecl/mvcapp:$ver
		docker push cdecl/mvcapp:$ver
	fi
fi

