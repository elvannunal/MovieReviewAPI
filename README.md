# MovieReviewAPI
MovieReviewAPI, API Katmanlı Mimari kullanılarak oluşturulmuştur. Bu proje, genel olarak "CRUD" (Create, Read, Update, Delete) işlemlerini ele alır ve ilişkili yapılar içerir. API, "fluent API" ile desteklenen ilişkili veri yapıları oluşturulmuştur. Bu ilişki yapısı "bire-çok" şeklindedir. Ayrıca projenin temelleri, "Repository Design Pattern" ile atılmıştır. API, "Extensions" metotları ile de zenginleştirilmiştir. Veri Transfer Nesneleri (DTO) ve AutoMapper kullanılarak veri aktarımı bunlar ile sağlanmıştır.

---
## Proje Detayları
* CRUD işlemleri için uygun yapılandırılmıştır.
* Veritabanı ilişkileri "fluent API" ile yönetilir.
* Veritabanı işlemleri "Repository Design Pattern" ile soyutlanır.
* API, "Extensions" metotları ile genişletilir ve ek işlevselliğe olanak tanır.
* DTO' lar ile verilerin farklı katmanlar arasında kolayca taşınması sağlanır.
* Prejede kullanmış olduğum "AutoMapper" sayesinde veri tabanı modelleri ile DTO'lar arasında otomatik dönüşüm sağlanır.
  
---
Bu proje, MovieReviewAPI için geliştirilmiş bir RESTful API sunar. İlişkili veri yapıları, "fluent API" sayesinde veritabanında düzenli ve tutarlı bir yapı oluşturulmasını sağlar. Ayrıca, "Repository Design Pattern" kullanılarak veritabanı işlemleri soyutlanmış, böylece kodun bakımı ve testi kolaylaştırılmıştır. "Extensions" metotları, API'ye ek işlevselliğin kolayca eklenmesini sağlar.


# MovieReviewAPI
MovieReviewAPI has been developed using the API Layered Architecture. This project primarily handles "CRUD" (Create, Read, Update, Delete) operations and includes related data structures. The API supports related data structures with the help of the "fluent API," and this relationship structure is "one-to-many." Furthermore, the project's foundation is built using the "Repository Design Pattern." The API is enriched with "Extensions" methods. Data Transfer Objects (DTOs) and AutoMapper are used for data transfer.
 ---
## Project Details
* Configured for CRUD operations.
* Manages database relationships with the "fluent API".
* Abstracts database operations using the "Repository Design Pattern".
* Enriched with "Extensions" methods, providing additional functionality.
* Facilitates data transfer between different layers using DTOs.
* Automapper enables automatic conversion between database models and DTOs.

  ---
This project offers a RESTful API for MovieReviewAPI. The use of the "fluent API" ensures a consistent and organized database structure for related data in a "one-to-many" relationship. Additionally, the "Repository Design Pattern" abstracts database operations, making maintenance and testing of the code easier. The inclusion of "Extensions" methods allows for easy extension of the API's functionality. Data Transfer Objects (DTOs) and AutoMapper are utilized to facilitate data transfer between different layers of the application.




