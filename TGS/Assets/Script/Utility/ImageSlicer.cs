using UnityEngine;
using System.IO;

/*
 * 画像を等間隔で分割して保存してくれるプログラム
 * http://setchi.hatenablog.com/entry/2015/03/08/175937
 */

public class ImageSlicer : MonoBehaviour
{
    [SerializeField]
    Texture2D texture;

    [SerializeField]
    int horizontalSlices;

    [SerializeField]
    int verticalSlices;

    [SerializeField]
    string saveDirectoryPath = "slicedImages/";

    int partWidth;
    int partHeight;

    void Start()
    {
        // 保存先ディレクトリが存在しなければ作成
        if (!Directory.Exists(saveDirectoryPath))
            Directory.CreateDirectory(saveDirectoryPath);

        SliceImage();
    }

    void SliceImage()
    {
        partWidth = texture.width / horizontalSlices;
        partHeight = texture.height / verticalSlices;
        var fileNameIndex = 0;

        for (var partY = verticalSlices; partY > 0; partY--)
        {
            for (var partX = 0; partX < horizontalSlices; partX++)
            {
                // 分割した一枚分のピクセルたちを取得
                var partPixels = ReadPartPixels(partX, partY, texture);

                // 新しいテクスチャに書き込む
                var partTexture = new Texture2D(partWidth, partHeight, TextureFormat.RGBA32, false);
                partTexture.SetPixels(partPixels);
                partTexture.Apply();

                // テクスチャをpngにしてローカルに保存
                SaveBinaryToLocal(partTexture.EncodeToPNG(), fileNameIndex + ".png");
                fileNameIndex++;
            }
        }
    }

    Color[] ReadPartPixels(int partX, int partY, Texture2D texture)
    {
        var pixels = new Color[partWidth * partHeight];
        var offsetX = partX * partWidth;
        var offsetY = partY * partHeight;

        for (int y = offsetY, y_ = partHeight - 1; y > offsetY - partHeight; y--, y_--)
        {
            for (int x = offsetX, x_ = 0; x < offsetX + partWidth; x++, x_++)
            {
                pixels[y_ * partWidth + x_] = texture.GetPixel(x, y);
            }
        }

        return pixels;
    }

    void SaveBinaryToLocal(byte[] binaryData, string fileName)
    {
        var fileStream = new FileStream(saveDirectoryPath + fileName, FileMode.Create, FileAccess.Write);
        var binaryWriter = new BinaryWriter(fileStream);

        binaryWriter.Write(binaryData);

        binaryWriter.Close();
        fileStream.Close();
    }
}