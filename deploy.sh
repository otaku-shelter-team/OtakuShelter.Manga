PREVIOUS_VERSION=`expr $TRAVIS_BUILD_NUMBER - 1`

echo docker pull otakushelter/otaku-shelter.manga:1.0.$TRAVIS_BUILD_NUMBER
echo docker rm $(docker stop $(docker ps -a -q --filter ancestor=otakushelter/otaku-shelter.manga:1.0.$PREVIOUS_VERSION --format="{{.ID}}"))
echo docker rmi otakushelter/otaku-shelter.manga:1.0.$PREVIOUS_VERSION -f 
echo docker run -d -p 80:80 otakushelter/otaku-shelter.manga:1.0.$TRAVIS_BUILD_NUMBER