echo "cd /root/OtakuShelter.Infrastructure/src && \
ansible-playbook deploy.yml \
-e \"\
otakushelter_hosts=mangas \
otakushelter_container=otakushelter_manga \
otakushelter_image=otakushelter/manga \
otakushelter_port=4001 \
otakushelter_build_number=$TRAVIS_BUILD_NUMBER \
otakushelter_database_password=$OTAKUSHELTER_DATABASE_PASSWORD\" \
-i inventories/staging"