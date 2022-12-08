using System.Drawing;

/// <summary>
/// Chartのアイテムクラス
/// </summary>
public class ChartItem
{
    public ChartItem(int [] data)
    {
        if (data is null)
            throw new ArgumentNullException("data");

        this.Data = data;
        Data = data;
    }

    public int[]? Data { get; set; }

    public string? Label { get; set; } = "ChartItem";

    public Color[] BackgroundColors { get; set; }

    public string? Options { get; set; }
 
    public override string ToString()
    {
        var str = "";
        var colors = ConvertColorToString(this.BackgroundColors);

        if (this.Data != null)
        {
            str = "{" +
                String.Join(", ", new string[]
                    {
                                $"\"label\": \"{this.Label}\"",
                                $"\"data\": [{string.Join(", ", this.Data)}]",
                                $"\"backgroundColor\": [{string.Join(", ", colors)}]",
                   });
            if(Options != null)
            {
                str = str + "," + Options;
            }
            str += "}";
        }

        return str;
    }

    private List<string> ConvertColorToString(Color[] color)
    {
        var strColors = new List<string>();

        for (int i = 0; i < color.Length; i++)
        {
            var str = $"\"rgba({color[i].R}, {color[i].G}, {color[i].B}, {color[i].A / 255.0})\"";
            strColors.Add(str);
        }
        return strColors;
    }
}

