PREVIOUS_VERSION=`expr $TRAVIS_BUILD_NUMBER - 1`

echo docker pull otakushelter/otaku-shelter.manga:1.0.$TRAVIS_BUILD_NUMBER
echo docker stop otakushelter/otaku-shelter.manga:1.0.$PREVIOUS_VERSION
echo docker rmi otakushelter/otaku-shelter.manga:1.0.$PREVIOUS_VERSION -f 
echo docker run -d otakushelter/otaku-shelter.manga:1.0.$TRAVIS_BUILD_NUMBER