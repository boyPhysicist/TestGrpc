Install OpenSLL https://www.openssl.org/source/

set OPENSSL_CONF=C:\Program Files\OpenSSL-Win64\bin\openssl.cfg - using PowerShell

With help of command line from OpenSSL bin folder:
Generate CA key: openssl genrsa -passout pass:1111 -des3 -out ca.key 4096
Generate CA certificate: openssl req -passin pass:1111 -new -x509 -days 365 -key ca.key -out ca.crt -subj  "/C=BY/ST=Gr/L=Test/O=YourCompany/OU=YourApp/CN=MyRootCA"(for example)
Generate server key: openssl genrsa -passout pass:1111 -des3 -out server.key 4096
Generate server signing request: openssl req -passin pass:1111 -new -key server.key -out server.csr -subj  "/C=BY/ST=Gr/L=Test/O=YourCompany/OU=YourApp/CN=localhost"(for example)
Self-sign server certificate: openssl x509 -req -passin pass:1111 -days 365 -in server.csr -CA ca.crt -CAkey ca.key -set_serial 01 -out server.crt
Remove passphrase from server key: openssl rsa -passin pass:1111 -in server.key -out server.key
Generate client key: openssl genrsa -passout pass:1111 -des3 -out client.key 4096
Generate client signing request: openssl req -passin pass:1111 -new -key client.key -out client.csr -subj  "/C=BY/ST=Gr/L=Testo/O=YourCompany/OU=YourApp/CN=localhost"(for example)
Self-sign client certificate: openssl x509 -passin pass:1111 -req -days 365 -in client.csr -CA ca.crt -CAkey ca.key -set_serial 01 -out client.crt
Remove passphrase from client key: openssl rsa -passin pass:1111 -in client.key -out client.key

or try to use cert.bat