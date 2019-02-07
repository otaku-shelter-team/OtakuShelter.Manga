PREVIOUS_VERSION=`expr $TRAVIS_BUILD_NUMBER - 1`

docker stop otakushelter/otaku-shelter.manga:1.0.$PREVIOUS_VERSION
docker pull otakushelter/otaku-shelter.manga:1.0.$TRAVIS_BUILD_NUMBER
docker run -d otakushelter/otaku-shelter.manga:1.0.$TRAVIS_BUILD_NUMBER