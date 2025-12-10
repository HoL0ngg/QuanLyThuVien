# KPIBox User Control - Hý?ng d?n s? d?ng

## Gi?i thi?u
`KPIBox` là m?t UserControl tùy ch?nh ðý?c thi?t k? ð? hi?n th? các ch? s? KPI (Key Performance Indicators) m?t cách ð?p m?t và nh?t quán trong các trang th?ng kê.

## Tính nãng
- Hi?n th? tiêu ð? và giá tr? KPI
- Tùy ch?nh màu s?c theo ? ngh?a (xanh dýõng, xanh lá, ð?, cam, tím, xám)
- H? tr? ð?nh d?ng s? t? ð?ng (phân cách hàng ngh?n, v.v.)
- D? dàng tích h?p vào các form th?ng kê

## Cách s? d?ng

### 1. Kh?i t?o KPIBox trong UserControl

```csharp
public partial class UCThongKeExample : UserControl
{
    // Khai báo KPIBox
    private KPIBox kpiTongSoLuong;
    private KPIBox kpiGiaTriDuong;
    private KPIBox kpiGiaTriAm;
    
    public UCThongKeExample()
    {
        InitializeComponent();
        InitializeKPIBoxes();
    }
    
    private void InitializeKPIBoxes()
    {
        // T?o instance
        kpiTongSoLuong = new KPIBox { Dock = DockStyle.Fill };
        kpiGiaTriDuong = new KPIBox { Dock = DockStyle.Fill };
        kpiGiaTriAm = new KPIBox { Dock = DockStyle.Fill };
        
        // Thêm vào panel týõng ?ng
        pnlKpi1.Controls.Clear();
        pnlKpi1.Controls.Add(kpiTongSoLuong);
        
        pnlKpi2.Controls.Clear();
        pnlKpi2.Controls.Add(kpiGiaTriDuong);
        
        pnlKpi3.Controls.Clear();
        pnlKpi3.Controls.Add(kpiGiaTriAm);
    }
}
```

### 2. Thi?t l?p giá tr? KPI

S? d?ng phýõng th?c `SetKPI()`:

```csharp
private void LoadKPIs()
{
    // Ví d? 1: Hi?n th? s? nguyên v?i màu xanh dýõng
    kpiTongSoLuong.SetKPI(
        "T?NG S? Ð?C GI?",     // Tiêu ð?
        1234,                    // Giá tr? (int)
        KPIBox.ColorBlue,        // Màu s?c
        "N0"                     // Format: N0 = phân cách hàng ngh?n
    );
    
    // Ví d? 2: Hi?n th? giá tr? dýõng v?i màu xanh lá
    kpiGiaTriDuong.SetKPI(
        "Ð?C GI? HO?T Ð?NG",
        856,
        KPIBox.ColorGreen,
        "N0"
    );
    
    // Ví d? 3: Hi?n th? c?nh báo v?i màu ð?
    kpiGiaTriAm.SetKPI(
        "Ð?C GI? CÓ N? PH?T",
        42,
        KPIBox.ColorRed,
        "N0"
    );
}
```

### 3. Màu s?c có s?n

KPIBox cung c?p các màu s?c ðý?c ð?nh ngh?a s?n:

```csharp
KPIBox.ColorBlue    // #2196F3 - Xanh dýõng (thông tin chung)
KPIBox.ColorGreen   // #4CAF50 - Xanh lá (tích c?c, t?t)
KPIBox.ColorRed     // #F44336 - Ð? (c?nh báo, l?i, n?)
KPIBox.ColorOrange  // #FF9800 - Cam (c?nh báo nh?)
KPIBox.ColorPurple  // #9C27B0 - Tím (ð?c bi?t)
KPIBox.ColorGray    // #757575 - Xám (trung l?p)
```

### 4. Ð?nh d?ng s?

S? d?ng các format string c?a .NET:

```csharp
// Phân cách hàng ngh?n
"N0"    // 1234567 ? 1,234,567

// Ti?n t?
"C0"    // 1234567 ? $1,234,567 (tùy culture)

// Ph?n trãm
"P0"    // 0.85 ? 85%
"P2"    // 0.8567 ? 85.67%

// S? th?p phân
"F2"    // 123.456 ? 123.46
```

## Ví d? th?c t?

### Ví d? 1: Th?ng kê ð?c gi?
```csharp
DataRow kpis = ThongKeBUS.Instance.GetDocGiaKPIs();
if (kpis != null)
{
    kpiTongDocGia.SetKPI(
        "T?NG S? Ð?C GI?",
        Convert.ToInt32(kpis["TongDocGia"]),
        KPIBox.ColorBlue,
        "N0"
    );
    
    kpiDocGiaMoi.SetKPI(
        "Ð?C GI? M?I (30 NGÀY)",
        Convert.ToInt32(kpis["DocGiaMoi"]),
        KPIBox.ColorBlue,
        "N0"
    );
    
    kpiDocGiaHoatDong.SetKPI(
        "Ð?C GI? HO?T Ð?NG",
        Convert.ToInt32(kpis["DocGiaHoatDong"]),
        KPIBox.ColorGreen,
        "N0"
    );
    
    kpiDocGiaNoTien.SetKPI(
        "Ð?C GI? CÓ N? PH?T",
        Convert.ToInt32(kpis["DocGiaNoTien"]),
        KPIBox.ColorRed,
        "N0"
    );
}
```

### Ví d? 2: Th?ng kê phi?u mý?n
```csharp
int tongPhieu = _view.Count;
int tongLuotSach = _view.Sum(p => p.CTPM?.Count ?? 0);
int daTraHoanTat = _view.Count(p => p.TrangThai == 2);
int dangMoQuaHan = _view.Count(p => p.TrangThai == 1 || p.TrangThai == 3);

kpiTongPhieu.SetKPI(
    "T?NG S? PHI?U MÝ?N",
    tongPhieu,
    KPIBox.ColorBlue,
    "N0"
);

kpiTongLuotSach.SetKPI(
    "T?NG LÝ?T SÁCH MÝ?N",
    tongLuotSach,
    KPIBox.ColorBlue,
    "N0"
);

kpiDaTraHoanTat.SetKPI(
    "PHI?U Ð? TR? HOÀN T?T",
    daTraHoanTat,
    KPIBox.ColorGreen,
    "N0"
);

kpiDangMoQuaHan.SetKPI(
    "PHI?U ÐANG M?/QUÁ H?N",
    dangMoQuaHan,
    KPIBox.ColorOrange,
    "N0"
);
```

### Ví d? 3: Th?ng kê phí ph?t
```csharp
decimal tongPhiPhat = _view.Sum(x => x.tienPhat);
decimal daThu = _view.Where(x => x.TrangThai == 1).Sum(x => x.tienPhat);
decimal chuaThu = _view.Where(x => x.TrangThai == 0).Sum(x => x.tienPhat);

kpiTongPhiPhat.SetKPI(
    "T?NG PHÍ PH?T",
    tongPhiPhat,
    KPIBox.ColorRed,
    "N0"
);

kpiDaThu.SetKPI(
    "T?NG THU TH?C T?",
    daThu,
    KPIBox.ColorGreen,
    "N0"
);

kpiChuaThu.SetKPI(
    "PHÍ CHÝA THU",
    chuaThu,
    KPIBox.ColorOrange,
    "N0"
);
```

## Lýu ?
- Ð?m b?o panel ch?a KPIBox có `Dock = DockStyle.Fill` ho?c kích thý?c phù h?p
- G?i `SetKPI()` m?i khi c?n c?p nh?t giá tr?
- S? d?ng màu s?c phù h?p v?i ? ngh?a c?a KPI (xanh = t?t, ð? = c?nh báo, v.v.)
