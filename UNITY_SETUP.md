# Unity 프로젝트 설정 가이드

## 🎮 Unity 버전

**추천 버전**: Unity 2022 LTS (2022.3.0 이상)

---

## 📦 설치 및 프로젝트 생성

### 1단계: Unity Hub에서 프로젝트 생성

```
1. Unity Hub 실행
2. "New Project" 클릭
3. 버전 선택: 2022 LTS
4. 템플릿 선택: 3D (Built-in Render Pipeline)
5. 프로젝트명: "3D-Shop-Simulator"
6. 저장 위치: 원하는 폴더 선택
7. "Create project" 클릭
```

### 2단계: Git 저장소 연동

```bash
cd [프로젝트 폴더]
git clone https://github.com/hseojin1224-design/3d-shop-simulator.git .
git add .
git commit -m "Initial commit"
git push origin main
```

---

## 📁 폴더 구조 생성

Unity 프로젝트의 `Assets` 폴더 내에 다음 구조를 생성하세요:

```
Assets/
├── Scripts/
│   ├── Core/
│   │   ├── GameManager.cs
│   │   ├── MoneySystem.cs
│   │   ├── TimeManager.cs
│   │   └── GameConstants.cs
│   ├── Player/
│   │   ├── PlayerController.cs
│   │   ├── PlayerPickup.cs
│   │   ├── PlayerCamera.cs
│   │   └── PlayerInput.cs
│   ├── Shop/
│   │   ├── Shelf.cs
│   │   ├── Warehouse.cs
│   │   ├── ShelfInventory.cs
│   │   ├── ProductBox.cs
│   │   └── Checkout.cs
│   ├── Customer/
│   │   ├── CustomerSpawner.cs
│   │   ├── CustomerAI.cs
│   │   ├── CustomerBehavior.cs
│   │   └── CustomerData.cs
│   ├── Product/
│   │   ├── Product.cs
│   │   ├── ProductData.cs
│   │   └── ProductManager.cs
│   └── UI/
│       ├── UIManager.cs
│       ├── MoneyUI.cs
│       ├── InventoryUI.cs
│       ├── SalesUI.cs
│       └── HUD.cs
├── Scenes/
│   ├── MainGame.unity
│   └── Menu.unity
├── Prefabs/
│   ├── Products/
│   │   ├── ProductBox.prefab
│   │   └── Product_A.prefab
│   ├── Shop/
│   │   ├── Shelf.prefab
│   │   ├── Checkout.prefab
│   │   └── Warehouse.prefab
│   └── Customer/
│       └── Customer.prefab
├── Models/
│   ├── Shop/
│   ├── Products/
│   └── Furniture/
├── Materials/
│   ├── Shop/
│   └── UI/
├── Textures/
├── Audio/
├── Resources/
│   ├── Products/
│   └── UI/
└── Editor/
    └── EditorTools.cs
```

---

## 🔧 Unity 프로젝트 설정

### Player Settings

```
File → Build Settings → Player Settings

1. Company Name: 자신의 이름 또는 팀명
2. Product Name: 3D Shop Simulator
3. Version: 0.1.0
4. Resolution and Presentation
   - Default Screen Width: 1920
   - Default Screen Height: 1080
   - Fullscreen Mode: Windowed
```

### Physics Settings

```
Edit → Project Settings → Physics

1. Gravity: (0, -9.81, 0)
2. Default Material
   - Friction: 0.4
   - Bounciness: 0.4
3. Solver Iterations: 6
4. Solver Velocity Iterations: 1
```

### Quality Settings

```
Edit → Project Settings → Quality

1. Active Quality Level: "High Fidelity"
2. V Sync Count: Don't Sync (60 FPS)
3. Target Frame Rate: 60
```

### Input Manager

```
Edit → Project Settings → Input Manager

필요한 입력:
- Horizontal (A/D)
- Vertical (W/S)
- Mouse X/Y
- Jump (Space)
- Interact (E)
- Place (R)
- Fire1 (Left Click)
```

---

## 📦 필요한 패키지

### Package Manager에서 설치

```
Window → TextMesh Pro → Import TMP Essentials
```

### 권장 패키지

```
Open Window → Package Manager

1. TextMesh Pro (자동 포함)
2. UI Toolkit (옵션)
3. Cinemachine (카메라 추적용)
4. Netcode for GameObjects (멀티플레이 검토시)
```

---

## 🎨 기본 씬 설정

### MainGame 씬 생성

```
1. File → New Scene
2. Scene 이름: MainGame.unity
3. Assets/Scenes 폴더에 저장
```

### 기본 GameObject 배치

```
1. 3D Object → Plane (바닥)
   - 이름: Ground
   - Scale: (10, 1, 10)
   - Position: (0, 0, 0)

2. 3D Object → Cube (벽)
   - 이름: Wall
   - Position, Scale 조정

3. Lighting → Light (조명)
   - Directional Light 추가
   - Intensity: 1.0
   - Rotation: X=50, Y=-30

4. Create Empty (플레이어)
   - 이름: Player
   - 자식 오브젝트: Camera

5. Camera
   - Player의 자식으로 설정
   - Position: (0, 0.6, 0)
   - Tag: MainCamera
```

---

## 💾 코드 작성 환경

### Visual Studio Code (권장)

```
1. Unity에서 VS Code 설정
   Edit → Preferences → External Tools
   External Script Editor: Visual Studio Code 선택

2. 필요한 확장 프로그램
   - C# (Microsoft)
   - Unity Code Snippets
   - Mono Debugger
```

### 또는 Visual Studio 2022 Community (무료)

```
1. Visual Studio Installer에서 Unity 워크로드 설치
2. Unity에서 VS 2022 선택
```

---

## 🚀 프로젝트 실행

```
1. Assets/Scenes/MainGame.unity 열기
2. Play 버튼 클릭
3. 콘솔에서 오류 확인
```

---

## 📝 주의사항

- Unity를 처음 열 때 마이크로소프트 계정 로그인 필수
- 프로젝트는 항상 Git에 커밋하기 (최소 일 1회)
- .gitignore에서 Library, Temp, obj 폴더는 제외됨
- 에셋은 Assets 폴더 내에만 보관
- 스크린샷은 Screenshots 폴더에 저장

---

## 🎯 다음 단계

1. PlayerController 스크립트 작성
2. 기본 상점 맵 제작
3. 상품 데이터 정의
4. 테스트 및 빌드
