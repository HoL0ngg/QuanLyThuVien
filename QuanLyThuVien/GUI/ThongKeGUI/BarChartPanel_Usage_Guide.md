# BarChartPanel - Hý?ng d?n s? d?ng

## Gi?i thi?u
`BarChartPanel` là m?t UserControl tái s? d?ng ð? hi?n th? bi?u ð? d?ng thanh ngang (horizontal bar chart). Control này giúp b?n d? dàng t?o các bi?u ð? th?ng kê ð?p m?t mà không c?n vi?t l?i code.

## Tính nãng
- Hi?n th? nhi?u thanh bi?u ð? v?i t? l? t? ð?ng
- Tùy ch?nh màu s?c cho t?ng thanh
- T? ð?ng tính t? l? chi?u dài thanh d?a trên giá tr? l?n nh?t
- Hi?n th? ðõn v? tùy ch?nh (ð?c gi?, lý?t mý?n, v.v.)
- H? tr? ð?nh d?ng s? v?i phân cách hàng ngh?n
- T? ð?ng hi?n th? "Chýa có d? li?u" khi không có data

## Cách s? d?ng

### 1. Kh?i t?o BarChartPanel

```csharp
public partial class UCThongKeExample : UserControl
{
    private BarChartPanel chartExample;
    
    public UCThongKeExample()
    {
        InitializeComponent();
        InitializeBarCharts();
    }
    
    private void InitializeBarCharts()
    {
        // T?o instance
        chartExample = new BarChartPanel
        {
            Dock = DockStyle.Fill,
            ValueUnit = "ð?c gi?"  // Ðõn v? hi?n th?
        };
        
        // Ð?t tiêu ð?
        chartExample.SetTitle("CÕ C?U HO?T Ð?NG Ð?C GI?");
        
        // Thêm vào panel
        panelContainer.Controls.Add(chartExample);
    }
}
```

### 2. Load d? li?u t? DataTable

**Cách 1: S? d?ng LoadData() v?i List<BarChartItem>**

```csharp
private void LoadCoCauHoatDong()
{
    DataTable dt = ThongKeBUS.Instance.GetCoCauHoatDongDocGia();
    if (dt == null || dt.Rows.Count == 0)
    {
        chartCoCauHoatDong.ClearData();
        return;
    }

    Color[] colors = new Color[]
    {
        Color.FromArgb(33, 150, 243),   // Ðang mý?n - Blue
        Color.FromArgb(76, 175, 80),    // Ð? tr? - Green
        Color.FromArgb(244, 67, 54),    // Quá h?n - Red
        Color.FromArgb(158, 158, 158)   // Chýa mý?n - Gray
    };

    List<BarChartItem> items = new List<BarChartItem>();
    int colorIndex = 0;

    foreach (DataRow row in dt.Rows)
    {
        string trangThai = row["TrangThai"].ToString();
        int soLuong = Convert.ToInt32(row["SoLuong"]);
        Color color = colors[colorIndex % colors.Length];

        items.Add(new BarChartItem(trangThai, soLuong, color));
        colorIndex++;
    }

    chartCoCauHoatDong.LoadData(items);
}
```

**Cách 2: Thêm t?ng item th? công v?i AddBarItem()**

```csharp
private void LoadDataManual()
{
    chartExample.ClearData();
    
    // T?m giá tr? l?n nh?t
    int maxValue = 100;
    
    // Thêm t?ng thanh
    chartExample.AddBarItem("Ðang mý?n sách", 60, maxValue, Color.FromArgb(33, 150, 243));
    chartExample.AddBarItem("Ð? tr? h?t sách", 25, maxValue, Color.FromArgb(76, 175, 80));
    chartExample.AddBarItem("Có sách quá h?n", 10, maxValue, Color.FromArgb(244, 67, 54));
    chartExample.AddBarItem("Chýa mý?n sách", 5, maxValue, Color.FromArgb(158, 158, 158));
}
```

### 3. Ví d? Top 5 v?i màu x?p h?ng

```csharp
private void LoadTop5DocGia()
{
    DataTable dt = ThongKeBUS.Instance.GetTop5DocGiaMuonNhieu();
    if (dt == null || dt.Rows.Count == 0)
    {
        chartTop5DocGia.ClearData();
        return;
    }

    List<BarChartItem> items = new List<BarChartItem>();
    int rank = 1;

    foreach (DataRow row in dt.Rows)
    {
        string tenDocGia = row["TenDocGia"].ToString();
        int tongLuot = Convert.ToInt32(row["TongLuotMuon"]);
        Color color = GetRankColor(rank);

        items.Add(new BarChartItem($"#{rank} {tenDocGia}", tongLuot, color));
        rank++;
    }

    chartTop5DocGia.LoadData(items);
}

private Color GetRankColor(int rank)
{
    switch (rank)
    {
        case 1: return Color.FromArgb(255, 193, 7);   // Gold
        case 2: return Color.FromArgb(158, 158, 158); // Silver
        case 3: return Color.FromArgb(205, 127, 50);  // Bronze
        default: return Color.FromArgb(33, 150, 243); // Blue
    }
}
```

### 4. Tùy ch?nh ðõn v? hi?n th?

```csharp
// Ví d? 1: Hi?n th? "ð?c gi?"
chartCoCauHoatDong.ValueUnit = "ð?c gi?";
// K?t qu?: "6 ð?c gi?"

// Ví d? 2: Hi?n th? "lý?t mý?n"
chartTop5.ValueUnit = "lý?t mý?n";
// K?t qu?: "3 lý?t mý?n"

// Ví d? 3: Hi?n th? "ð?u sách"
chartTheLoai.ValueUnit = "ð?u sách";
// K?t qu?: "45 ð?u sách"

// Ví d? 4: Không hi?n th? ðõn v?
chartExample.ValueUnit = "";
// K?t qu?: "120"
```

### 5. Class BarChartItem

```csharp
// Constructor
public BarChartItem(string label, int value, Color color)

// Properties
public string Label { get; set; }   // Nh?n hi?n th?
public int Value { get; set; }      // Giá tr? s?
public Color Color { get; set; }    // Màu s?c thanh

// Ví d?
var item = new BarChartItem("Ðang mý?n sách", 60, Color.FromArgb(33, 150, 243));
```

## Các phýõng th?c chính

### SetTitle(string title)
Thi?t l?p tiêu ð? cho bi?u ð?

```csharp
chartExample.SetTitle("CÕ C?U HO?T Ð?NG Ð?C GI?");
```

### ClearData()
Xóa toàn b? d? li?u hi?n t?i

```csharp
chartExample.ClearData();
```

### LoadData(List<BarChartItem> items)
Load d? li?u t? danh sách items, t? ð?ng tính t? l?

```csharp
List<BarChartItem> items = new List<BarChartItem>
{
    new BarChartItem("Item 1", 100, Color.Blue),
    new BarChartItem("Item 2", 75, Color.Green),
    new BarChartItem("Item 3", 50, Color.Red)
};
chartExample.LoadData(items);
```

### AddBarItem(string label, int value, int maxValue, Color barColor)
Thêm m?t thanh vào bi?u ð?

```csharp
chartExample.AddBarItem("Ðang mý?n", 60, 100, Color.FromArgb(33, 150, 243));
```

## Màu s?c ph? bi?n

```csharp
// Màu KPIBox có s?n
Color.FromArgb(33, 150, 243)   // KPIBox.ColorBlue - Xanh dýõng
Color.FromArgb(76, 175, 80)    // KPIBox.ColorGreen - Xanh lá
Color.FromArgb(244, 67, 54)    // KPIBox.ColorRed - Ð?
Color.FromArgb(255, 152, 0)    // KPIBox.ColorOrange - Cam
Color.FromArgb(156, 39, 176)   // KPIBox.ColorPurple - Tím
Color.FromArgb(117, 117, 117)  // KPIBox.ColorGray - Xám

// Màu x?p h?ng
Color.FromArgb(255, 193, 7)    // Gold - Vàng
Color.FromArgb(158, 158, 158)  // Silver - B?c
Color.FromArgb(205, 127, 50)   // Bronze - Ð?ng
```

## Ví d? hoàn ch?nh

```csharp
public partial class UCThongKeSach : UserControl
{
    private BarChartPanel chartTheLoai;
    private BarChartPanel chartNamXB;
    
    public UCThongKeSach()
    {
        InitializeComponent();
        InitializeCharts();
        LoadData();
    }
    
    private void InitializeCharts()
    {
        // Bi?u ð? th? lo?i
        chartTheLoai = new BarChartPanel
        {
            Dock = DockStyle.Fill,
            ValueUnit = "ð?u sách"
        };
        chartTheLoai.SetTitle("?? CÕ C?U SÁCH THEO TH? LO?I");
        panelTheLoai.Controls.Add(chartTheLoai);
        
        // Bi?u ð? nãm xu?t b?n
        chartNamXB = new BarChartPanel
        {
            Dock = DockStyle.Fill,
            ValueUnit = "ð?u sách"
        };
        chartNamXB.SetTitle("?? PHÂN B? THEO NÃM XU?T B?N");
        panelNamXB.Controls.Add(chartNamXB);
    }
    
    private void LoadData()
    {
        LoadTheLoai();
        LoadNamXuatBan();
    }
    
    private void LoadTheLoai()
    {
        var items = new List<BarChartItem>
        {
            new BarChartItem("Vãn h?c", 45, Color.FromArgb(33, 150, 243)),
            new BarChartItem("Truy?n tranh", 38, Color.FromArgb(76, 175, 80)),
            new BarChartItem("Khoa h?c", 32, Color.FromArgb(255, 152, 0)),
            new BarChartItem("L?ch s?", 28, Color.FromArgb(156, 39, 176)),
            new BarChartItem("K? nãng s?ng", 25, Color.FromArgb(244, 67, 54))
        };
        
        chartTheLoai.LoadData(items);
    }
    
    private void LoadNamXuatBan()
    {
        int currentYear = DateTime.Now.Year;
        var items = new List<BarChartItem>
        {
            new BarChartItem($"Nãm {currentYear}", 65, Color.FromArgb(76, 175, 80)),
            new BarChartItem($"Nãm {currentYear - 1}", 58, Color.FromArgb(76, 175, 80)),
            new BarChartItem($"Nãm {currentYear - 2}", 42, Color.FromArgb(76, 175, 80)),
            new BarChartItem($"Nãm {currentYear - 3}", 35, Color.FromArgb(76, 175, 80)),
            new BarChartItem($"Nãm {currentYear - 4}", 28, Color.FromArgb(76, 175, 80))
        };
        
        chartNamXB.LoadData(items);
    }
}
```

## Lýu ?
- BarChartPanel t? ð?ng tính t? l? thanh d?a trên giá tr? l?n nh?t
- N?u giá tr? > 0 nhýng thanh quá nh?, nó s? có ð? dài t?i thi?u 5px ð? d? nh?n
- Màu s?c nên phù h?p v?i ? ngh?a: xanh lá = t?t, ð? = c?nh báo, xanh dýõng = trung l?p
- Label quá dài s? t? ð?ng hi?n th? d?u "..." (ellipsis)
- Ðõn v? (ValueUnit) s? ðý?c thêm vào sau giá tr? s?
