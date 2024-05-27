��� ���������� ���� ��������� ����������, ��� ���������� ��������� ��������� ����:

--�������������� ER-���������.
--������� ���� ������ � �������, ��������������� 3NF.
--�������� �������� ������.
--������� ��������� ��� �������� ����������� �����.
--������� ������� ������� ��������� ��� � ������� ��� � ����������.
--��� 1: ER-���������
--ER-��������� ����� �������� ��������� �������� � �����:

--������ (Client)

--id (PK)
--���
--�������
--�������� (NULL)
--�������
--email
--���� ��������
--��������� (Employee)

--id (PK, GUID)
--���
--�������
--�������� (NULL)
--���� ��������
--�������
--����� (�����, �����, ���, ��������)
--����� (Product)

--id (PK)
--�������
--������������
--���������
--����
--����������� (NULL)
--������� ���������
--���� ������������
--���� ��������
--����� �������������
--������ �������������
--����� (Order)

--id (PK)
--������_id (FK)
--���� ������
--������
--���������� (OrderProduct)

--�����_id (PK, FK)
--�����_id (PK, FK)
--����������
--������� (Purchase)

--id (PK)
--������_id (FK)
--���������_id (FK)
--���� �������
--������ ������
--������������ (PurchaseProduct)

--�������_id (PK, FK)
--�����_id (PK, FK)
--����������
--���������� (HistoryCost)

--id (PK)
--���� ���������
--�����_id (FK)
--������ ����
--����� ����



--��� 2: �������� ���� ������ � ������

CREATE DATABASE TorG;
USE TorG;

CREATE TABLE Client (
    id INT AUTO_INCREMENT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    middle_name VARCHAR(50) NULL,
    phone VARCHAR(15),
    email VARCHAR(100),
    birth_date DATE
);

CREATE TABLE Employee (
    id CHAR(36) PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    middle_name VARCHAR(50) NULL,
    birth_date DATE,
    phone VARCHAR(15),
    address_city VARCHAR(50),
    address_street VARCHAR(50),
    address_house VARCHAR(10),
    address_apartment VARCHAR(10)
);

CREATE TABLE Product (
    id INT AUTO_INCREMENT PRIMARY KEY,
    article VARCHAR(50),
    name VARCHAR(100),
    category VARCHAR(50),
    price DECIMAL(10, 2),
    image VARCHAR(255) NULL,
    unit VARCHAR(20),
    manufacture_date DATE,
    expiration_date DATE,
    manufacturer VARCHAR(100),
    country VARCHAR(50)
);

CREATE TABLE `Order` (
    id INT AUTO_INCREMENT PRIMARY KEY,
    client_id INT,
    order_date DATE,
    status VARCHAR(20),
    FOREIGN KEY (client_id) REFERENCES Client(id)
);

CREATE TABLE OrderProduct (
    order_id INT,
    product_id INT,
    quantity INT,
    PRIMARY KEY (order_id, product_id),
    FOREIGN KEY (order_id) REFERENCES `Order`(id),
    FOREIGN KEY (product_id) REFERENCES Product(id)
);

CREATE TABLE Purchase (
    id INT AUTO_INCREMENT PRIMARY KEY,
    client_id INT,
    employee_id CHAR(36),
    purchase_date DATE,
    payment_method VARCHAR(20),
    FOREIGN KEY (client_id) REFERENCES Client(id),
    FOREIGN KEY (employee_id) REFERENCES Employee(id)
);

CREATE TABLE PurchaseProduct (
    purchase_id INT,
    product_id INT,
    quantity INT,
    PRIMARY KEY (purchase_id, product_id),
    FOREIGN KEY (purchase_id) REFERENCES Purchase(id),
    FOREIGN KEY (product_id) REFERENCES Product(id)
);

CREATE TABLE HistoryCost (
    id INT AUTO_INCREMENT PRIMARY KEY,
    change_date DATE,
    product_id INT,
    old_price DECIMAL(10, 2),
    new_price DECIMAL(10, 2),
    FOREIGN KEY (product_id) REFERENCES Product(id)
);


--��� 3: ���������� �������� ������--

-- ���������� �������� ������ ��� ��������
INSERT INTO Client (first_name, last_name, middle_name, phone, email, birth_date)
VALUES 
('����', '������', '��������', '1234567890', 'ivanov@example.com', '1980-01-01'),
('����', '������', NULL, '0987654321', 'petrov@example.com', '1990-02-02');

-- ���������� �������� ������ ��� �����������
INSERT INTO Employee (id, first_name, last_name, middle_name, birth_date, phone, address_city, address_street, address_house, address_apartment)
VALUES 
(UUID(), '������', '�������', '���������', '1985-03-03', '1122334455', '������', '������', '10', '5'),
(UUID(), '������', '�������', NULL, '1992-04-04', '2233445566', '�����-���������', '�������', '20', '10');

-- ���������� �������� ������ ��� �������
INSERT INTO Product (article, name, category, price, unit, manufacture_date, expiration_date, manufacturer, country)
VALUES 
('001', '�����1', '���������1', 100.00, '��', '2023-01-01', '2024-01-01', '�����1', '������'),
('002', '�����2', '���������2', 200.00, '��', '2023-02-01', '2024-02-01', '�����2', '�����');

-- ���������� �������� ������ ��� �������
INSERT INTO `Order` (client_id, order_date, status)
VALUES 
(1, '2024-05-01', '�����'),
(2, '2024-05-02', '� ������');

-- ���������� �������� ������ ��� ������� � �������
INSERT INTO OrderProduct (order_id, product_id, quantity)
VALUES 
(1, 1, 5),
(1, 2, 3),
(2, 1, 2);

-- ���������� �������� ������ ��� �������
INSERT INTO Purchase (client_id, employee_id, purchase_date, payment_method)
VALUES 
(1, (SELECT id FROM Employee LIMIT 1), '2024-05-01', '��������'),
(2, (SELECT id FROM Employee LIMIT 1 OFFSET 1), '2024-05-02', '�����');

-- ���������� �������� ������ ��� ������� � �������
INSERT INTO PurchaseProduct (purchase_id, product_id, quantity)
VALUES 
(1, 1, 3),
(1, 2, 1),
(2, 1, 4);

--��� 4: �������� ��������� �������� ����������� �����--

DELIMITER $$

CREATE PROCEDURE ValidateEmails()
BEGIN
    DECLARE done INT DEFAULT FALSE;
    DECLARE email VARCHAR(100);
    DECLARE email_cursor CURSOR FOR SELECT email FROM Client;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
    DROP TEMPORARY TABLE IF EXISTS TempEmailValidation;
    CREATE TEMPORARY TABLE TempEmailValidation (
        email VARCHAR(100),
        is_valid BOOLEAN
    );
    
    OPEN email_cursor;
    read_loop: LOOP
        FETCH email_cursor INTO email;
        IF done THEN
            LEAVE read_loop;
        END IF;
        
        INSERT INTO TempEmailValidation (email, is_valid)
        VALUES (email, 
            (email REGEXP '^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$' 
            AND email NOT REGEXP '[\"\'<>]'));
    END LOOP;
    
    CLOSE email_cursor;
    
    SELECT * FROM TempEmailValidation;
END$$

DELIMITER ;


--��� 5: �������� ������� ������� ��������� ��� � ��������--

-- �������� �������� ��� ������ ��������� ���
DELIMITER $$

CREATE TRIGGER AfterProductPriceUpdate
AFTER UPDATE ON Product
FOR EACH ROW
BEGIN
    IF OLD.price <> NEW.price THEN
        INSERT INTO HistoryCost (change_date, product_id, old_price, new_price)
        VALUES (NOW(), OLD.id, OLD.price, NEW.price);
    END IF;
END$$

DELIMITER ;