#!/bin/bash

sudo pacman -S dotnet-sdk
sudo pacman -S aspnet-runtime

sudo dotnet tool install --global dotnet-ef