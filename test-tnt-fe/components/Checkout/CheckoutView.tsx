"use client";

import { useState } from "react";
import { isAxiosError } from "axios";
import Swal from "sweetalert2";
import { useCart } from "@/lib/cart-store";
import {
  checkout,
  type CheckoutErrorResponse,
  type CheckoutResponse,
} from "@/lib/api";
import { Button } from "@/components/ui/button";

interface CheckoutViewProps {
  cartTitle: string;
  cartEmptyLabel: string;
}

export function CheckoutView({ cartTitle, cartEmptyLabel }: CheckoutViewProps) {
  const { items, removeItem, updateQuantity, clear, totalPrice } = useCart();
  const [loading, setLoading] = useState(false);
  const [result, setResult] = useState<CheckoutResponse | null>(null);

  async function handleCheckout() {
    setLoading(true);
    try {
      const res = await checkout(
        items.map((i) => ({ productId: Number(i.id), quantity: i.quantity })),
      );
      setResult(res);
      clear();
    } catch (err) {
      const message =
        isAxiosError<CheckoutErrorResponse>(err) && err.response?.data?.message
          ? err.response.data.message
          : "เกิดข้อผิดพลาด ลองใหม่อีกครั้ง";
      Swal.fire({ icon: "error", title: "สั่งซื้อไม่สำเร็จ", text: message });
    } finally {
      setLoading(false);
    }
  }

  if (result) {
    return (
      <div className="mx-auto max-w-2xl w-full p-6">
        <h1 className="text-xl font-bold">สั่งซื้อสำเร็จ</h1>
        <p className="mt-2 text-gray-600">
          Order #{result.orderId} — ยอดรวม ฿{result.totalCost}
        </p>
      </div>
    );
  }

  return (
    <div className="mx-auto max-w-2xl w-full p-6 flex flex-col gap-6">
      <h1 className="text-xl font-bold">{cartTitle}</h1>

      {items.length === 0 ? (
        <p className="text-gray-400">{cartEmptyLabel}</p>
      ) : (
        <div className="flex flex-col gap-3">
          {items.map((item) => (
            <div
              key={item.id}
              className="flex items-center justify-between border-b pb-3"
            >
              <div>
                <p className="font-medium">{item.name}</p>
                <p className="text-xs text-gray-400">{item.code}</p>
                <p className="text-sm text-gray-500">฿{item.price}</p>
              </div>

              <div className="flex items-center gap-3">
                <div className="flex items-center gap-2">
                  <button
                    onClick={() => updateQuantity(item.id, item.quantity - 1)}
                    className="flex size-7 items-center justify-center rounded-full border hover:bg-black/5"
                    aria-label="ลดจำนวน"
                  >
                    −
                  </button>
                  <span className="w-6 text-center">{item.quantity}</span>
                  <button
                    onClick={() => updateQuantity(item.id, item.quantity + 1)}
                    className="flex size-7 items-center justify-center rounded-full border hover:bg-black/5"
                    aria-label="เพิ่มจำนวน"
                  >
                    +
                  </button>
                </div>

                <button
                  onClick={() => removeItem(item.id)}
                  className="text-sm text-rose-600 hover:underline"
                >
                  ลบ
                </button>
              </div>
            </div>
          ))}

          <div className="flex items-center justify-between pt-2 font-bold">
            <span>รวม</span>
            <span>฿{totalPrice}</span>
          </div>

          <Button onClick={handleCheckout} disabled={loading}>
            {loading ? "กำลังดำเนินการ..." : "ยืนยันการสั่งซื้อ"}
          </Button>
        </div>
      )}
    </div>
  );
}
