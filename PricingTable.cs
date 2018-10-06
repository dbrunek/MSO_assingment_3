using System;

namespace Lab3
{
    public static class PricingTable
    {
        public static float getPrice(int tariefeenheden, int col)
        {
            float price = 0f;

            switch (col)
            {
                case 0:
                    price = 2.10f;
                    break;
                case 1:
                    price = 1.70f;
                    break;
                case 2:
                    price = 1.30f;
                    break;
                case 3:
                    price = 3.60f;
                    break;
                case 4:
                    price = 2.90f;
                    break;
                case 5:
                    price = 2.20f;
                    break;
                default:
                    throw new Exception("Unknown column number");
            }

            price = price * 0.02f * (float)tariefeenheden;

            return (float)Math.Round(price, 2);
        }
    }
}

