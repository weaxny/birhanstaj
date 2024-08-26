package main

import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	reader := bufio.NewReader(os.Stdin)
	fmt.Println("Dosya işlemleri uygulamasına hoşgeldiniz!")
	fmt.Println("---------------------")

	currentDir, err := os.Getwd()
	if err != nil {
		fmt.Println("Geçerli dizin alınamadı:", err)
		return
	}

	for {
		fmt.Println("Bir işlem seçin:")
		fmt.Println("0. Dizindeki dosyaları listele")
		fmt.Println("1. Dosyaya veri ekle")
		fmt.Println("2. Dosyaya veri yaz (üzerine yazar)")
		fmt.Println("3. Dosyadan veri oku")
		fmt.Println("4. Çıkış")

		input, _ := reader.ReadString('\n')
		input = input[:len(input)-1]

		switch input {
		case "0":
			fmt.Println("Bir seçenek seçin:")
			fmt.Println("1. Mevcut dizindeki dosyaları listele")
			fmt.Println("2. Başka bir dizindeki dosyaları listele ve mevcut dizini değiştir")

			subInput, _ := reader.ReadString('\n')
			subInput = subInput[:len(subInput)-1]

			switch subInput {
			case "1":
				files, err := os.ReadDir(currentDir)
				if err != nil {
					fmt.Println("Dizin okunamadı:", err)
					continue
				}

				fmt.Println("Mevcut dizindeki dosyalar:")
				for _, file := range files {
					fmt.Println(file.Name())
				}
			case "2":
				fmt.Println("Dizin yolunu girin:")
				dirPath, _ := reader.ReadString('\n')
				dirPath = dirPath[:len(dirPath)-1]

				files, err := os.ReadDir(dirPath)
				if err != nil {
					fmt.Println("Dizin okunamadı:", err)
					continue
				}

				fmt.Println("Belirtilen dizindeki dosyalar:")
				for _, file := range files {
					fmt.Println(file.Name())
				}

				err = os.Chdir(dirPath)
				if err != nil {
					fmt.Println("Dizin değiştirilemedi:", err)
					continue
				}

				currentDir = dirPath
				fmt.Println("Mevcut dizin değiştirildi:", currentDir)
			default:
				fmt.Println("Geçersiz seçenek. Lütfen tekrar deneyin.")
			}
		case "1":
			fmt.Println("Dosya adını girin:")
			fileName, _ := reader.ReadString('\n')
			fileName = fileName[:len(fileName)-1]

			fmt.Println("Eklemek istediğiniz veriyi girin:")
			data, _ := reader.ReadString('\n')
			data = data[:len(data)-1]

			file, err := os.OpenFile(fileName, os.O_APPEND|os.O_WRONLY|os.O_CREATE, 0644)
			if err != nil {
				fmt.Println("Dosya açılamadı:", err)
				continue
			}
			defer file.Close()

			_, err = file.WriteString(data + "\n")
			if err != nil {
				fmt.Println("Veri eklenemedi:", err)
			} else {
				fmt.Println("Veri dosyaya eklendi.")
			}
		case "2":
			fmt.Println("Dosya adını girin:")
			fileName, _ := reader.ReadString('\n')
			fileName = fileName[:len(fileName)-1]

			fmt.Println("Yazmak istediğiniz veriyi girin:")
			data, _ := reader.ReadString('\n')
			data = data[:len(data)-1]

			file, err := os.Create(fileName)
			if err != nil {
				fmt.Println("Dosya oluşturulamadı:", err)
				continue
			}
			defer file.Close()

			_, err = file.WriteString(data)
			if err != nil {
				fmt.Println("Veri yazılamadı:", err)
			} else {
				fmt.Println("Veri dosyaya yazıldı.")
			}
		case "3":
			fmt.Println("Dosya adını girin:")
			fileName, _ := reader.ReadString('\n')
			fileName = fileName[:len(fileName)-1]

			file, err := os.Open(fileName)
			if err != nil {
				fmt.Println("Dosya açılamadı:", err)
				continue
			}
			defer file.Close()

			scanner := bufio.NewScanner(file)
			for scanner.Scan() {
				fmt.Println(scanner.Text())
			}

			if err := scanner.Err(); err != nil {
				fmt.Println("Dosya okunamadı:", err)
			}
		case "4":
			fmt.Println("Çıkış yapılıyor...")
			return
		default:
			fmt.Println("Geçersiz işlem. Lütfen tekrar deneyin.")
		}
	}
}
