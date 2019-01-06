
#!/bin/bash


dt=$(date '+RespaldosDB/plat_corcega_%Y%m%d_%H%M%S.sql');
echo "$dt"

mysqldump -u root -p plat_corcega > $dt
