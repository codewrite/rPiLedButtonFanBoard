  #!/bin/bash

echo "Executing command with params: $1 $2 $3 $4 $5"

if [ $# -ne 1 ]; then
  echo "Wrong number of arguments, got $# expected 1"
  echo ''
  echo 'Usage:  setPiName.sh <piName>'
  echo ''
  echo 'Example 1: setPiName.sh myRaspberryPi'
else
  sed -i "s@\("'"'"rpi\.Name"'"'": "'"'"\).*\("'"'"\)@\1$1\2@g" .vscode/settings.json
fi
