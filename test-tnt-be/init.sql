create table "Product" (
  "id" serial primary key,
  "code" VARCHAR(8) null,
  "product_name_th" varchar(255) null,
  "product_name_en" varchar(255) null,
  "stock" INT not null default 0,
  "cost_per_item" INT not null default 0,
  "created_at" timestamp not null default NOW(),
  "updated_at" timestamp not null default NOW()
);
comment on column "Product"."stock" is 'จำนวนคงเหลือ';
comment on column "Product"."cost_per_item" is 'ราคาสินค้าต่อชิ้น';

create table "Order" (
  "id" serial primary key,
  "created_at" timestamp not null default NOW()
);

create table "Order_item" (
  "id" serial primary key,
  "order_id" INT not null references "Order"("id"),
  "product_id" INT not null references "Product"("id"),
  "quantity" INT not null default 1,
  "cost_per_item" INT not null default 0,
  "created_at" timestamp not null default NOW()
);
comment on column "Order_item"."quantity" is 'จำนวนที่สั่งซื้อ';
comment on column "Order_item"."cost_per_item" is 'ราคาต่อชิ้น ณ ตอนสั่งซื้อ (snapshot)';

create index "idx_order_item_order_id" on "Order_item" ("order_id");
create index "idx_order_item_product_id" on "Order_item" ("product_id");
