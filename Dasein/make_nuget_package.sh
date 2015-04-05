#! /bin/bash

read -p "Did you build Release?!?!? " yn

if [ $yn = "y" ]
then

    nuget pack ./Dasein.nuspec
else
    echo "Then go do it"
    exit 1
fi











