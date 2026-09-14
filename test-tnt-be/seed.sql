insert into "Product" ("code", "product_name_th", "product_name_en", "stock", "cost_per_item") values
  ('P0001', 'เสื้อยืดสีขาว', 'White T-Shirt', 50, 199),
  ('P0002', 'เสื้อยืดสีดำ', 'Black T-Shirt', 30, 199),
  ('P0003', 'กางเกงยีนส์', 'Jeans', 20, 890),
  ('P0004', 'หมวกแก๊ป', 'Cap', 100, 250),
  ('P0005', 'ถุงเท้า', 'Socks', 200, 59);

insert into "Order" default values;
insert into "Order" default values;

insert into "Order_item" ("order_id", "product_id", "quantity", "cost_per_item") values
  (1, 1, 1, 199),
  (1, 2, 1, 199),
  (2, 3, 1, 890);
