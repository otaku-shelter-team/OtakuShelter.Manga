PREVIOUS_VERSION=`expr $TRAVIS_BUILD_NUMBER - 1`

echo docker stop otakushelter/otaku-shelter.manga:1.0.$PREVIOUS_VERSION
echo docker pull otakushelter/otaku-shelter.manga:1.0.$TRAVIS_BUILD_NUMBER
echo docker run -d otakushelter/otaku-shelter.manga:1.0.$TRAVIS_BUILD_NUMBER