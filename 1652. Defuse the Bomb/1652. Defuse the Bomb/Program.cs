class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    public int[] Decrypt(int[] code, int k) {
        int n = code.Length;
        int[] result = new int[n];

        // 如果 k 為 0，直接返回全為 0 的陣列
        if (k == 0) {
            return result;
        }

        // 建立一個長度為原陣列兩倍的新陣列，用於處理循環的情況
        int[] extendedCode = [..code, ..code];

        // 根據 k 的正負來決定要往前還是往後加總
        if (k > 0) {
            // k 為正數，往後加 k 個數
            for (int i = 0; i < n; i++) {
                int sum = 0;
                // 從目前位置的下一個數開始，加總後面 k 個數
                for (int j = 1; j <= k; j++) {
                    sum += extendedCode[i + j];
                }
                result[i] = sum;
            }
        } else {
            // k 為負數，往前加 |k| 個數
            k = -k; // 取絕對值
            for (int i = 0; i < n; i++) {
                int sum = 0;
                // 從目前位置往前加總 k 個數
                for (int j = 1; j <= k; j++) {
                    sum += extendedCode[i + n - j];
                }
                result[i] = sum;
            }
        }

        return result;
    }
}